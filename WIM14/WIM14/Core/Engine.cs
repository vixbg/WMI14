using System;
using System.Text;
using WIM14.Commands.Contracts;
using WIM14.Core.Contracts;

namespace WIM14.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WIM14.Core.Contracts.IEngine" />
    class Engine : IEngine
    {
        private static Engine instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static IEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }

                return instance;
            }
        }

        private readonly ICommandManager commandManager;

        /// <summary>
        /// Prevents a default instance of the <see cref="Engine"/> class from being created.
        /// </summary>
        private Engine()
        {
            this.commandManager = new CommandManager();
        }

        /// <summary>
        /// Runs the instance.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                string input = this.Read();

                if (input == "exit")
                    break;

                string result = this.Process(input);

                this.Print(result);
            }
        }

        /// <summary>
        /// Reads from the Console.
        /// </summary>
        /// <returns></returns>
        private string Read()
        {
            string input = Console.ReadLine();
            return input;
        }

        /// <summary>
        /// Processes the specified command line.
        /// </summary>
        /// <param name="commandLine">The command line to process.</param>
        /// <returns></returns>
        private string Process(string commandLine)
        {
            try
            {
                ICommand command = this.commandManager.ParseCommand(commandLine);
                string result = command.Execute();

                return result.Trim();
            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }

                return $"ERROR: {e.Message}";
            }
        }

        /// <summary>
        /// Prints the command result.
        /// </summary>
        /// <param name="commandResult">The command result to print.</param>
        private void Print(string commandResult)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(commandResult);
            sb.AppendLine("####################");
            Console.WriteLine(sb.ToString().Trim());
        }

    }
}

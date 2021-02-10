using System;
using System.Text;
using WIM14.Commands.Contracts;
using WIM14.Core.Contracts;

namespace WIM14.Core
{
    class Engine : IEngine
    {
        private static Engine instance;

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

        private Engine()
        {
            this.commandManager = new CommandManager();
        }
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

        private string Read()
        {
            string input = Console.ReadLine();
            return input;
        }
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
        private void Print(string commandResult)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(commandResult);
            sb.AppendLine("####################");
            Console.WriteLine(sb.ToString().Trim());
        }

    }
}

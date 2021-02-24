using System;
using System.Collections.Generic;
using WIM14.Commands.Contracts;
using WIM14.Core.Contracts;

namespace WIM14.Commands.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WIM14.Commands.Contracts.ICommand" />
    public abstract class Command : ICommand
    {
        protected readonly IDatabase Database;
        protected readonly IFactory Factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="commandParameters">The command parameters.</param>
        /// <param name="database">The database.</param>
        /// <param name="factory">The factory.</param>
        /// <exception cref="ArgumentNullException">
        /// database
        /// or
        /// factory
        /// </exception>
        protected Command(IList<string> commandParameters, IDatabase database, IFactory factory)
        {            
            this.CommandParameters = new List<string>(commandParameters);
            this.Database = database ?? throw new ArgumentNullException(nameof(database));
            this.Factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <returns></returns>
        public abstract string Execute();

        /// <summary>
        /// Gets the command parameters.
        /// </summary>
        protected IList<string> CommandParameters 
        {
            get;
        }

    }
}

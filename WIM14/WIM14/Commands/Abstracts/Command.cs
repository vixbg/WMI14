using System;
using System.Collections.Generic;
using WIM14.Commands.Contracts;
using WIM14.Core.Contracts;

namespace WIM14.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected readonly IDatabase Database;
        protected readonly IFactory Factory;
        protected Command(IList<string> commandParameters, IDatabase database, IFactory factory)
        {            
            this.CommandParameters = new List<string>(commandParameters);
            this.Database = database ?? throw new ArgumentNullException(nameof(database));
            this.Factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        public abstract string Execute();
        protected IList<string> CommandParameters 
        {
            get;
        }

    }
}

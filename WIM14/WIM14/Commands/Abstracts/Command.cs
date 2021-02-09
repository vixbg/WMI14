using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Commands.Contracts;
using WIM14.Core.Contracts;

namespace WIM14.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected Command(IList<string> commandParameters)
        {
            this.CommandParameters = new List<string>(commandParameters);
        }
        public abstract string Execute();
        protected IList<string> CommandParameters 
        {
            get;
        }

        protected IDatabase Database
        {
            get
            {
                return Core.Database.Instance;
            }
        }

        protected IFactory Factory
        {
            get
            {
                return Core.Factory.Instance;
            }
        }

    }
}

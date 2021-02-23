using System;
using System.Collections.Generic;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;

namespace WIM14.Commands
{
    class ShowAllMembersCommand : Command
    {
        //showallmembers 
        public ShowAllMembersCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters, database, factory)
        {
        }
        public override string Execute()
        {
            return this.Database.Members.Count > 0
                ? string.Join(Environment.NewLine, this.Database.Members).Trim()
                : "There are no registered members.";
        }
    }
}

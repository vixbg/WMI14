using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;

namespace WIM14.Commands
{
    //showallteams
    class ShowAllTeamsCommand : Command
    {
        public ShowAllTeamsCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters, database, factory)
        {
        }
        public override string Execute()
        {
            return this.Database.Members.Count > 0
                ? string.Join(Environment.NewLine, this.Database.Teams).Trim()
                : "There are no registered teams.";
        }
    }
}

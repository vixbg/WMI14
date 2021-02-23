using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;

namespace WIM14.Commands
{
    class ShowTeamActivityCommand : Command
    {
        //showteamactivity [TEAMNAME]
        public ShowTeamActivityCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters, database, factory)
        {
        }
        public override string Execute()
        {
            string teamName = this.CommandParameters[0];

            var team = this.Database.Teams.ToList().Find(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException($"Team does not exist.");
            }

            return team.ShowTeamActivity().Trim();
        }
    }
}

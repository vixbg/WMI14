using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;

namespace WIM14.Commands
{
    class ShowTeamActivityCommand : Command
    {
        //showteamactivity [TEAMNAME]
        public ShowTeamActivityCommand(IList<string> commandParameters) : base(commandParameters)
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

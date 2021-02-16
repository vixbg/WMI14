using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;

namespace WIM14.Commands
{
    class ShowTeamActivityCommand : Command
    {
        public ShowTeamActivityCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string teamName = this.CommandParameters[0];

            var desiredTeamIndex = this.Database.Teams.ToList().FindIndex(team => team.Name == teamName);

            if (desiredTeamIndex == -1)
            {
                throw new ArgumentException($"Team does not exist.");
            }

            return this.Database.Teams[desiredTeamIndex].ShowTeamActivity().Trim();
        }
    }
}

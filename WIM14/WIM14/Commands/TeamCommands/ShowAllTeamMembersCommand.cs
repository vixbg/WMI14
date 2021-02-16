using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;

namespace WIM14.Commands
{
    class ShowAllTeamMembersCommand : Command
    {
        public ShowAllTeamMembersCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string teamName = this.CommandParameters[0];

            if (!this.Database.Members.ToList().Exists(team => team.Name == teamName))
            {
                throw new ArgumentException($"Team does not exist.");
            }

            var desiredTeamIndex = this.Database.Members.ToList().FindIndex(team => team.Name == teamName);

            return string.Join(Environment.NewLine, this.Database.Teams[desiredTeamIndex].Members).Trim();
        }
    }
}

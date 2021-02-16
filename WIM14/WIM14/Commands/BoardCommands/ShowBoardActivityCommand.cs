using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;

namespace WIM14.Commands
{
    class ShowBoardActivityCommand : Command
    {
        public ShowBoardActivityCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string boardName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            var desiredTeamIndex = this.Database.Teams.ToList().FindIndex(team => team.Name == teamName);

            if (desiredTeamIndex == -1)
            {
                throw new ArgumentException("Team does not exist.");
            }

            if (!this.Database.Teams[desiredTeamIndex].Boards.Exists(board => board.Name == boardName))
            {
                throw new ArgumentException("Board does not exist.");
            }

            return this.Database.Teams[desiredTeamIndex].Boards.Find(board => board.Name == boardName).ToString();
        }
    }
}

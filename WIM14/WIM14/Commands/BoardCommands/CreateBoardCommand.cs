using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Models;

namespace WIM14.Commands
{
    public class CreateBoardCommand : Command
    {
        public CreateBoardCommand(List<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string boardName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            var boardToAdd = this.Factory.CreateBoard(boardName);
            var desiredTeamIndex = this.Database.Teams.ToList().FindIndex(team => team.Name == teamName);

            if(desiredTeamIndex == -1)
            {
                throw new ArgumentException("Team does not exist.");
            }

            this.Database.Teams[desiredTeamIndex].AddBoard((Board)boardToAdd);

            return $"Board {boardName} was added to {teamName}.";
        }
    }
}

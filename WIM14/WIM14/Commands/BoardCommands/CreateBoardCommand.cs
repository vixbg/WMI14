using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;
using WIM14.Models;

namespace WIM14.Commands
{
    public class CreateBoardCommand : Command
    { 
        //createboard [BOARDNAME] [TEAMNAME]
        public CreateBoardCommand(List<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters, database, factory)
        {
        }
        public override string Execute()
        {
            string boardName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];
            var team = this.Database.Teams.FirstOrDefault(t => t.Name == teamName);
            
            var newBoard = this.Factory.CreateBoard(boardName);
            //var desiredTeamIndex = this.Database.Teams.ToList().FindIndex(team => team.Name == teamName);

            if(team == null)
            {
                throw new ArgumentException("Team does not exist.");
            }

            //var existingBoardName = team.Boards.Exists(board => board.Name == boardName);

            if (team.Boards.Contains(newBoard))
            {
                throw new ArgumentException("Board already exists.");
            }

            team.AddBoard(newBoard);

            return $"Board {boardName} was created and added in team {teamName}.";
        }
    }
}

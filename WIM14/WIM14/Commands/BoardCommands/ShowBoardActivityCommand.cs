using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;

namespace WIM14.Commands
{
    class ShowBoardActivityCommand : Command
    {
        //showboardactivity [BOARDNAME] [TEAMNAME]
        public ShowBoardActivityCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters,  database,  factory)
        {
        }
        public override string Execute()
        {
            string boardName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            var team = this.Database.Teams.ToList().Find(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException("Team does not exist.");
            }

            if (!team.Boards.Exists(board => board.Name == boardName))
            {
                throw new ArgumentException("Board does not exist.");
            }

            return string.Join(Environment.NewLine, team.Boards
                .Find(board => board.Name == boardName)
                .ToString())
                .Trim();
        }
    }
}

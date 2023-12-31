﻿using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;

namespace WIM14.Commands
{
    class ShowAllTeamBoardsCommand : Command
    {
        //showallteamboards [TEAMNAME]
        public ShowAllTeamBoardsCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters, database, factory)
        {
        }
        public override string Execute()
        {
            string teamName = this.CommandParameters[0];

            if (!this.Database.Teams.ToList().Exists(t => t.Name == teamName))
            {
                throw new ArgumentException($"Team does not exist.");
            }
            
            var team = this.Database.Teams.ToList().Find(t => t.Name == teamName);

            return string.Join(Environment.NewLine, team.Boards).Trim();
        }
    }
}

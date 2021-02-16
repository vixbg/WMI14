using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;
using WIM14.Models.Contracts;

namespace WIM14.Commands
{
    class CreateTeamCommand : Command
    {
        public CreateTeamCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string teamName = this.CommandParameters[0];

            if (this.Database.Teams.ToList().Exists(team => team.Name == teamName))
            {
                throw new ArgumentException($"Name {teamName} is taken. Please provide a unique name.");
            }

            ITeam newMember = this.Factory.CreateTeam(teamName);

            this.Database.Teams.Add(newMember);

            return $"Team with ID {this.Database.Members.Count - 1} was created.";
        }
    }
}

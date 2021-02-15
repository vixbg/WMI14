using System;
using System.Collections.Generic;
using WIM14.Commands.Abstracts;
using WIM14.Models;
using System.Linq;

namespace WIM14.Commands
{
    class AddMemberCommand : Command
    {
        public AddMemberCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string memberName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            var desiredMember = this.Database.Members.ToList().Find(member => member.Name == memberName);
            var desiredTeamIndex = this.Database.Teams.ToList().FindIndex(team => team.Name == teamName);

            if (desiredMember == null)
            {
                throw new ArgumentException($"Member with name {memberName} does not exist.");
            }

            if (desiredTeamIndex == -1)
            {
                throw new ArgumentException($"Team with name {teamName} does not exist.");
            }

            this.Database.Teams[desiredTeamIndex].AddPerson((Member)desiredMember); //WHY CAST ?!

            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using WIM14.Commands.Abstracts;
using WIM14.Models;
using System.Linq;


namespace WIM14.Commands
{
    public class AddMemberCommand : Command
    {
        //addmember [MEMBERNAME] [TEAMNAME]
        public AddMemberCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            if(this.CommandParameters.Count != 2)
            {
                throw new ArgumentException("Invalid parameter count. Command addmember needs [MEMBERNAME] [TEAMNAME] to work.");
            }

            string memberName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            var member = this.Database.Members.ToList().Find(m => m.Name == memberName);
            var team = this.Database.Teams.ToList().Find(t => t.Name == teamName);

            if (member == null)
            {
                throw new ArgumentException($"Member with name {memberName} does not exist.");
            }

            if (team == null)
            {
                throw new ArgumentException($"Team with name {teamName} does not exist.");
            }

            team.AddPerson(member);

            return $"Member {memberName} was added to team {teamName}.";
        }
    }
}

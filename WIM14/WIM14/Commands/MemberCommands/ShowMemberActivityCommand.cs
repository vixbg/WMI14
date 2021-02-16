using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;

namespace WIM14.Commands
{
    class ShowMemberActivityCommand : Command
    {
        public ShowMemberActivityCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string memberName = this.CommandParameters[0];

            var desiredMemberIndex = this.Database.Members.ToList().FindIndex(member => member.Name == memberName);

            if(desiredMemberIndex == -1)
            {
                throw new ArgumentException($"Member does not exist.");
            }

            return this.Database.Members[desiredMemberIndex].ShowActivityHistory().Trim();
        }
    }
}

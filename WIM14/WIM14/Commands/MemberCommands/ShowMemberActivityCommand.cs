using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;

namespace WIM14.Commands
{
    class ShowMemberActivityCommand : Command
    {
        //showmemberactivity [MEMBERNAME]
        public ShowMemberActivityCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string memberName = this.CommandParameters[0];

            var member = this.Database.Members.ToList().Find(member => member.Name == memberName);

            if(member == null)
            {
                throw new ArgumentException($"Member does not exist.");
            }

            return member.ShowActivityHistory().Trim();
        }
    }
}

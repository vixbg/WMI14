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
            var memberActivityist = this.Database.Members.Select(member => member.ShowActivityHistory());

            return string.Join(Environment.NewLine, memberActivityist);
        }
    }
}

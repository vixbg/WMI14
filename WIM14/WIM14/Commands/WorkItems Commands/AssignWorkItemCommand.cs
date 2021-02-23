using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;

namespace WIM14.Commands
{
    class AssignWorkItemCommand : Command
    {
        public AssignWorkItemCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters, database, factory)
        {
        }
        public override string Execute()
        {
            if (this.CommandParameters.Count < 1 || this.CommandParameters.Count > 2)
            {
                throw new ArgumentException("Not enough parameters. Please provide ID of a work item and a member's name.");
            }

            int workItemID;
            string memberName;

            try
            {
                int.TryParse(this.CommandParameters[0], out workItemID);
                memberName = this.CommandParameters[1];
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to parse Assign parameters.");
            }

            if(workItemID < 0 || workItemID > this.Database.WorkItems.Count)
            {
                throw new ArgumentException($"Please provide ID within 0 and {this.Database.WorkItems.Count}");
            }

            var workItemToAssign = this.Database.WorkItems[workItemID];
            var member = this.Database.Members.ToList().Find(member => member.Name == memberName);
            if (member == null)
            {
                throw new ArgumentException("No member found with that name.");
            }

            member.AssignWorkItem(workItemToAssign);

            if (workItemToAssign is IBug)
            {
                var item = (IBug)workItemToAssign;
                item.Assignee = member;
            }
            else if (workItemToAssign is IStory)
            {
                var item = (IStory)workItemToAssign;
                item.Assignee = member;
            }

            return $"{workItemToAssign.GetType().Name} {workItemToAssign.Title} was assigned to member {member.Name}.";
        }
    }
}

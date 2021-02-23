using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;

namespace WIM14.Commands
{
    class UnassignWorkItemCommand : Command
    {
        public UnassignWorkItemCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters, database, factory)
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

            if (workItemID < 0 || workItemID > this.Database.WorkItems.Count)
            {
                throw new ArgumentException($"Please provide ID within 0 and {this.Database.WorkItems.Count}");
            }

            var workItemToAssign = this.Database.WorkItems[workItemID];
            var member = this.Database.Members.ToList().Find(member => member.Name == memberName);

            member.UnassignWorkItem(workItemToAssign);

            return $"{workItemToAssign.GetType().Name} {workItemToAssign.Title} was unassigned.";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class ChangeBugPriorityCommand : Command
    {
        public ChangeBugPriorityCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            int id;
            IBug bug;
            Priority previouPriority;
            Priority newPriority;
            try
            {
                //TODO: Validations
                
                id = int.Parse(this.CommandParameters[0]);
                bug = this.Database.WorkItems.FirstOrDefault(b => b.Id == id) as IBug;
                newPriority = Enum.Parse<Priority>(this.CommandParameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeBugPriority command parameters.");
            }
            if (bug == null)
            {
                throw new Exception($"No bug was found with id {id}");
            }
            previouPriority = bug.Priority;
            bug.Priority = newPriority;

            return $"Priority changed on Bug with ID{bug.Id} from {previouPriority} to {bug.Priority}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class ChangeBugPrioriyCommand : Command
    {
        public ChangeBugPrioriyCommand(IList<string> commandParameters) : base(commandParameters)
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
                bug = (IBug)this.Database.WorkItems.First(b => b.Id == id);
                newPriority = Enum.Parse<Priority>(this.CommandParameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeBugPriority command parameters.");
            }
            previouPriority = bug.Priority;
            bug.Priority = newPriority;

            return $"Priority changed on Bug with ID{bug.Id} from {previouPriority} to {bug.Priority}";
        }
    }
}

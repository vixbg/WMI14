using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class ChangeBugStatusCommand : Command
    {
        public ChangeBugStatusCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            int id;
            IBug bug;
            BugStatus previouStatus;
            BugStatus newStatus;
            try
            {
                //TODO: Validations
                id = int.Parse(this.CommandParameters[0]);
                bug = (IBug)this.Database.WorkItems.First(b => b.Id == id);
                newStatus = Enum.Parse<BugStatus>(this.CommandParameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeBugStatus command parameters.");
            }
            previouStatus = bug.Status;
            bug.Status = newStatus;

            return $"Status changed on Bug with ID{bug.Id} from {previouStatus} to {bug.Status}";
        }
    }
}

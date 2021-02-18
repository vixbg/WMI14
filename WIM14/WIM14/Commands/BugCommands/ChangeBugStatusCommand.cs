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
                bug = this.Database.WorkItems.FirstOrDefault(b => b.Id == id) as IBug;
                newStatus = Enum.Parse<BugStatus>(this.CommandParameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeBugStatus command parameters.");
            }
            if (bug == null)
            {
                throw new Exception($"No bug was found with id {id}");
            }
            previouStatus = bug.Status;
            bug.Status = newStatus;

            return $"Status changed on Bug with ID{bug.Id} from {previouStatus} to {bug.Status}";
        }
    }
}

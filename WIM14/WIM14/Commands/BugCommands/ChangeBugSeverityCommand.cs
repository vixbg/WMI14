using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class ChangeBugSeverityCommand : Command
    {
        public ChangeBugSeverityCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            int id;
            IBug bug;
            Severity previouSeverity;
            Severity newSeverity;
            try
            {
                //TODO: Validations
                id = int.Parse(this.CommandParameters[0]);
                bug = (IBug)this.Database.WorkItems.First(b => b.Id == id);
                newSeverity = Enum.Parse<Severity>(this.CommandParameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeBugSeverity command parameters.");
            }
            previouSeverity = bug.Severity;
            bug.Severity = newSeverity;

            return $"Severity changed on Bug with ID{bug.Id} from {previouSeverity} to {bug.Severity}";
        }
    }
}

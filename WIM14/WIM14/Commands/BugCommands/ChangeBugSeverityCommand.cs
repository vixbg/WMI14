using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class ChangeBugSeverityCommand : Command
    {
        public ChangeBugSeverityCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters,  database,  factory)
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
                bug = this.Database.WorkItems.FirstOrDefault(b => b.Id == id) as IBug;
                newSeverity = Enum.Parse<Severity>(this.CommandParameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeBugSeverity command parameters.");
            }
            if (bug == null)
            {
                throw new Exception($"No bug was found with id {id}");
            }
            previouSeverity = bug.Severity;
            bug.Severity = newSeverity;

            return $"Severity changed on Bug with ID{bug.Id} from {previouSeverity} to {bug.Severity}";
        }
    }
}

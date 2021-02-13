using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Models;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class CreateBugCommand : Command
    {
        public CreateBugCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string title;
            string description;
            List<string> stepsToReproduce;
            Priority priority;
            Severity severity;
            
            try
            {
                //TODO: Validations
                title = this.CommandParameters[0];
                description = this.CommandParameters[1];
                stepsToReproduce = this.CommandParameters[2].Split("|", StringSplitOptions.None).ToList();
                priority = Enum.Parse<Priority>(this.CommandParameters[3]);
                severity = Enum.Parse<Severity>(this.CommandParameters[4]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBug command parameters.");
            }

            IBug bug = this.Factory.CreateBug(title, description, stepsToReproduce, priority, severity);

            this.Database.WorkItems.Add((IBug)bug);

            return $"Bug with ID:{bug.Id} and Title:{bug.Title} was created.";
        }
    }
}

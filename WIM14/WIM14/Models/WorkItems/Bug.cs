using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models.WorkItems
{
    class Bug : Abstracts.WorkItem<BugStatus>, IBug, IType
    {
        private readonly Type type = Type.Bug;


        public Bug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity) : base(title, description)
        {
            this.StepsToReproduce = stepsToReproduce;
            this.Priority = priority;
            this.Severity = severity;
            this.Status = BugStatus.Active;
            //TODO: Add history entry.
            
        }

        public Type Type => type;

        public List<string> StepsToReproduce { get; set; }

        public Priority Priority { get; set; }

        public Severity Severity { get; set; }

        public IMember Assignee { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Type} ----");
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Status: {Status}");
            sb.AppendLine($"Priority: {Priority}");
            sb.AppendLine($"Severity: {Severity}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Description: {Description}");
            sb.AppendLine($"Assignee: {Assignee}");
            sb.AppendLine($"Steps to Reproduce: {StepsToReproduce}");
            sb.AppendLine($"Comments: {Comments}"); //How to Print? Foreach! Or use Method.

            return sb.ToString().Trim();
        }
    }
}

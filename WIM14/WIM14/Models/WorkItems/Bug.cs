using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Core;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models.WorkItems
{
    public class Bug : Abstracts.WorkItem<BugStatus>, IBug, IType
    {
        private readonly Type type = Type.Bug;
        private Severity severity;
        private IMember assginee;
        private Priority priority;

        public Bug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity) : base(title, description)
        {
            this.StepsToReproduce = stepsToReproduce;
            this.Priority = priority;
            this.Severity = severity;
            this.Status = BugStatus.Active;
            
            

        }

        public Type Type => type;

        public List<string> StepsToReproduce { get; set; }

        public Priority Priority
        {
            get => this.priority;
            set
            {
                AddHistoryItem($"Priority changed from {this.Priority} to {value}");
                this.priority = value;

            }
        }

        public Severity Severity {
            get => this.severity;
            set
            {
                AddHistoryItem($"Severity changed from {this.Severity} to {value}");
                this.severity = value;
                
            }
        }

        public IMember Assignee
        {
            get => this.assginee;
            set
            {
                
                this.assginee = value;
                AddHistoryItem($"Assignee {value} added.");
            }
        }

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
            sb.AppendLine($"Steps to Reproduce:");
            StepsToReproduce.ForEach(s => sb.AppendLine($"|{s}|"));
            Comments.ForEach(c => sb.AppendLine($"Comments: {c}"));

            return sb.ToString().Trim();
        }

    }
}

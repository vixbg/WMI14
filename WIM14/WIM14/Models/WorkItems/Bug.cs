using System.Collections.Generic;
using System.Text;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Models.WorkItems
{
    /// <summary>
    /// Bug Class
    /// </summary>
    /// <seealso cref="WIM14.Models.Abstracts.WorkItem{WIM14.Models.Enums.BugStatus}" />
    /// <seealso cref="WIM14.Models.Contracts.IBug" />
    /// <seealso cref="WIM14.Models.Contracts.IType" />
    public class Bug : Abstracts.WorkItem<BugStatus>, IBug
    {
        private Severity severity;
        private IMember assginee;
        private Priority priority;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bug"/> class.
        /// </summary>
        /// <param name="title">String between 10 and 50 chars.</param>
        /// <param name="description">String between 10 and 500 chars.</param>
        /// <param name="stepsToReproduce">Strings separated by "|".</param>
        /// <param name="priority">High, Medium, Low</param>
        /// <param name="severity">Critical, Major, Minor.</param>
        public Bug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity) : base(title, description)
        {
            this.StepsToReproduce = stepsToReproduce;
            this.Priority = priority;
            this.Severity = severity;
            this.Status = BugStatus.Active;
            this.Assignee = new Member("Not Assigned");
            
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Type Type => type;

        /// <summary>
        /// Gets or sets the steps to reproduce.
        /// </summary>
        /// <value>
        /// The steps to reproduce.
        /// </value>
        public List<string> StepsToReproduce { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>
        /// The priority.
        /// </value>
        public Priority Priority
        {
            get => this.priority;
            set
            {
                AddHistoryItem($"Priority changed from {this.Priority} to {value}");
                this.priority = value;

            }
        }

        /// <summary>
        /// Gets or sets the severity.
        /// </summary>
        /// <value>
        /// The severity.
        /// </value>
        public Severity Severity {
            get => this.severity;
            set
            {
                AddHistoryItem($"Severity changed from {this.Severity} to {value}");
                this.severity = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the assignee.
        /// </summary>
        /// <value>
        /// The assignee.
        /// </value>
        public IMember Assignee
        {
            get => this.assginee;
            set
            {
                
                this.assginee = value;
                AddHistoryItem($"Assignee {value} added.");
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{WorkItemType} ----");
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

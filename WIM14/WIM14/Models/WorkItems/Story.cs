using System.Text;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models.WorkItems
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WIM14.Models.Abstracts.WorkItem{WIM14.Models.Enums.StoryStatus}" />
    /// <seealso cref="WIM14.Models.Contracts.IStory" />
    /// <seealso cref="WIM14.Models.Contracts.IType" />
    public class Story : Abstracts.WorkItem<StoryStatus>, IStory, IType
    {
        private Type type = Type.Story;
        private Priority priority;
        private Size size;
        private IMember assginee;

        /// <summary>
        /// Initializes a new instance of the <see cref="Story"/> class.
        /// </summary>
        /// <param name="title">String between 10 and 50 chars.</param>
        /// <param name="description">String between 10 and 500 chars.</param>
        /// <param name="priority">High, Medium, Low.</param>
        /// <param name="size">Large, Medium, Small.</param>
        public Story(string title, string description, Priority priority, Size size) : base(title, description)
        {
            this.Priority = priority;
            this.Size = size;
            this.Status = StoryStatus.NotDone;
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Type Type => type;

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
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public Size Size
        {
            get => this.size;
            set
            {
                AddHistoryItem($"Size changed from {this.Priority} to {value}");
                this.size = value;
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
            sb.AppendLine($"{Type} ----");
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Status: {Status}");
            sb.AppendLine($"Priority: {Priority}");
            sb.AppendLine($"Size: {Size}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Description: {Description}");
            sb.AppendLine($"Assignee: {Assignee}");
            Comments.ForEach(c => sb.AppendLine($"Comments: {c}"));

            return sb.ToString().Trim();
        }
    }
}

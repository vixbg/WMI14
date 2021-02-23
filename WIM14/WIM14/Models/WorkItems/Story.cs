using System.Text;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models.WorkItems
{
    public class Story : Abstracts.WorkItem<StoryStatus>, IStory, IType
    {
        private Type type = Type.Story;
        private Priority priority;
        private Size size;
        private IMember assginee;

        public Story(string title, string description, Priority priority, Size size) : base(title, description)
        {
            this.Priority = priority;
            this.Size = size;
            this.Status = StoryStatus.NotDone;
        }

        public Type Type => type;

        public Priority Priority
        {
            get => this.priority;
            set
            {
                AddHistoryItem($"Priority changed from {this.Priority} to {value}");
                this.priority = value;

            }
        }

        public Size Size
        {
            get => this.size;
            set
            {
                AddHistoryItem($"Size changed from {this.Priority} to {value}");
                this.size = value;

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
            sb.AppendLine($"Size: {Size}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Description: {Description}");
            sb.AppendLine($"Assignee: {Assignee}");
            Comments.ForEach(c => sb.AppendLine($"Comments: {c}"));

            return sb.ToString().Trim();
        }
    }
}

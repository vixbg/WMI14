using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models.WorkItems
{
    class Story : Abstracts.WorkItems<StoryStatus>, IStory, IType
    {
        private Type type = Type.Story;

        public Story(string title, string description, Priority priority, Size size, IMember assignee) : base(title, description)
        {
            this.Priority = priority;
            this.Size = size;
            this.Assignee = assignee;
            this.Status = StoryStatus.NotDone;
        }

        public Type Type => type;

        public Priority Priority { get; set; }

        public Size Size { get; set; }

        public IMember Assignee { get; set; }

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
            sb.AppendLine($"Comments: {Comments}"); //How to Print?

            return sb.ToString().Trim();
        }
    }
}

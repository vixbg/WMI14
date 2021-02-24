using System;
using System.Text;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Models.WorkItems
{
    public class Feedback : Abstracts.WorkItem<FeedbackStatus>, IFeedback
    {
        private WorkItemType workItemType = WorkItemType.Feedback;
        private int rating;

        public Feedback(string title, string description, int rating) : base(title, description, WorkItemType.Feedback)
        {
            this.Rating = rating;
            this.Status = FeedbackStatus.New;

        }

        public WorkItemType WorkItemType => workItemType;
        public int Rating
        {
            get => rating;
            set
            {
                rating = ValidateRating(value);
                AddHistoryItem($"Feedback rating changed to {value}.");
            } 

        }

        
        private int ValidateRating(int value)
        {
            if (value < 0 || value > 5)
            {
                throw new ArgumentException("Rating should be a number between 0 and 5.");
            }

            return value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{WorkItemType} ----");
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Description: {Description}");
            sb.AppendLine(this.rating == 1 ? $"Rating: {Rating} star." : $"Rating: {Rating} stars.");
            Comments.ForEach(c => sb.AppendLine($"Comments: {c}"));

            return sb.ToString().Trim();
        }
    }
}

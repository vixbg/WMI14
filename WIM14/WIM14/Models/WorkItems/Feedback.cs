using System;
using System.Text;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models.WorkItems
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WIM14.Models.Abstracts.WorkItem{WIM14.Models.Enums.FeedbackStatus}" />
    /// <seealso cref="WIM14.Models.Contracts.IFeedback" />
    /// <seealso cref="WIM14.Models.Contracts.IType" />
    public class Feedback : Abstracts.WorkItem<FeedbackStatus>, IFeedback, IType
    {
        private Type type = Type.Feedback;
        private int rating;

        /// <summary>
        /// Initializes a new instance of the <see cref="Feedback"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="title">String between 10 and 50 chars.</param>
        /// <param name="description">String between 10 and 500 chars.</param>
        /// <param name="rating">Integer between 1 and 5.</param>
        public Feedback(string title, string description, int rating) : base(title, description)
        {
            this.Rating = rating;
            this.Status = FeedbackStatus.New;
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Type Type => type;

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public int Rating
        {
            get => rating;
            set
            {
                rating = ValidateRating(value);
                AddHistoryItem($"Feedback rating changed to {value}.");
            } 
        }

        /// <summary>
        /// Validates the rating.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Rating should be a number between 0 and 5.</exception>
        private int ValidateRating(int value)
        {
            if (value < 0 || value > 5)
            {
                throw new ArgumentException("Rating should be a number between 0 and 5.");
            }
            return value;
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
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Description: {Description}");
            sb.AppendLine(this.rating == 1 ? $"Rating: {Rating} star." : $"Rating: {Rating} stars.");
            Comments.ForEach(c => sb.AppendLine($"Comments: {c}"));

            return sb.ToString().Trim();
        }
    }
}

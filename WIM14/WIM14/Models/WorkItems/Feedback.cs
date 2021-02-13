﻿using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models.WorkItems
{
    class Feedback : Abstracts.WorkItem<FeedbackStatus>, IFeedback, IType
    {
        private Type type = Type.Feedback;
        private int rating;

        public Feedback(string title, string description, int rating) : base(title, description)
        {
            this.Rating = rating;
            this.Status = FeedbackStatus.New;

        }

        public Type Type => type;
        public int Rating
        {
            get => rating;
            set => rating = ValidateRating(value);
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
            sb.AppendLine($"{Type} ----");
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Description: {Description}");
            if (this.rating == 1)
            {
                sb.AppendLine($"Rating: {Rating} star.");
            }
            else
            {
                sb.AppendLine($"Rating: {Rating} stars.");
            }
            sb.AppendLine($"Comments: {Comments}"); //How to Print?

            return sb.ToString().Trim();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;

namespace WIM14.Commands
{
    class ChangeFeedbackRatingCommand : Command
    {
        public ChangeFeedbackRatingCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters,  database,  factory)
        {
        }
        public override string Execute()
        {
            int id;
            IFeedback feedback;
            int previousRating;
            int newRating;

            try
            {
                id = int.Parse(this.CommandParameters[0]);
                feedback = this.Database.WorkItems.FirstOrDefault(f => f.Id == id) as IFeedback;
                newRating = int.Parse(this.CommandParameters[1]);
            }
            catch 
            {
                throw new ArgumentException("Failed to parse ChangeFeedbackRating command parameters.");
            }
            if (feedback == null)
            {
                throw new Exception($"No feedback was found with id {id}");
            }

            previousRating = feedback.Rating;
            feedback.Rating = newRating;

            return feedback.Rating == 1 
                ? $"Rating changed on Feedback with ID{feedback.Id} from {previousRating}stars to {feedback.Rating}star." 
                : previousRating == 1 
                    ? $"Rating changed on Feedback with ID{feedback.Id} from {previousRating}star to {feedback.Rating}stars" 
                    : $"Rating changed on Feedback with ID{feedback.Id} from {previousRating}stars to {feedback.Rating}stars"; 

            //TODO:Fix plural star/stars
        }
    }
}

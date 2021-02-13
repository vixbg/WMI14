using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Models.Contracts;

namespace WIM14.Commands
{
    class ChangeFeedbackRatingCommand : Command
    {
        public ChangeFeedbackRatingCommand(IList<string> commandParameters) : base(commandParameters)
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
                feedback = (IFeedback)this.Database.WorkItems.First(f => f.Id == id);
                newRating = int.Parse(this.CommandParameters[1]);
            }
            catch 
            {
                throw new ArgumentException("Failed to parse ChangeFeedbackRating command parameters.");
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

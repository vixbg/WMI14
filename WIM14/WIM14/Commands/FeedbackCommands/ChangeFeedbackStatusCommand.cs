using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class ChangeFeedbackStatusCommand : Command
    {
        public ChangeFeedbackStatusCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters, database, factory)
        {
        }
        public override string Execute()
        {
            int id;
            IFeedback feedback;
            FeedbackStatus previouStatus;
            FeedbackStatus newStatus;
            try
            {
                //TODO: Validations
                id = int.Parse(this.CommandParameters[0]);
                feedback = this.Database.WorkItems.FirstOrDefault(f => f.Id == id) as IFeedback;
                newStatus = Enum.Parse<FeedbackStatus>(this.CommandParameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeFeedbackStatus command parameters.");
            }
            if (feedback == null)
            {
                throw new Exception($"No feedback was found with id {id}");
            }
            previouStatus = feedback.Status;
            feedback.Status = newStatus;

            return $"Status changed on Feedback with ID{feedback.Id} from {previouStatus} to {feedback.Status}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class ChangeFeedbackStatusCommand : Command
    {
        public ChangeFeedbackStatusCommand(IList<string> commandParameters) : base(commandParameters)
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
                feedback = (IFeedback)this.Database.WorkItems.First(f => f.Id == id);
                newStatus = Enum.Parse<FeedbackStatus>(this.CommandParameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeFeedbackStatus command parameters.");
            }
            previouStatus = feedback.Status;
            feedback.Status = newStatus;

            return $"Status changed on Feedback with ID{feedback.Id} from {previouStatus} to {feedback.Status}";
        }
    }
}

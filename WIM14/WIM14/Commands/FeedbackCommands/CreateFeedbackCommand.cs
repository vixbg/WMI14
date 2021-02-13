using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Models.Contracts;

namespace WIM14.Commands
{
    class CreateFeedbackCommand : Command
    {
        public CreateFeedbackCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string title;
            string description;
            int raiting;

            try
            {
                //TODO: Validations
                title = this.CommandParameters[0];
                description = this.CommandParameters[1];
                raiting = int.Parse(this.CommandParameters[2]);
            }
            catch 
            {
                throw new ArgumentException("Failed to parse CreateFeedback command parameters.");
            }

            IFeedback feedback = this.Factory.CreateFeedback(title, description, raiting);

            this.Database.WorkItems.Add((IFeedback)feedback);
            return $"Feedback with ID:{feedback.Id} and Title:{feedback.Title} was created.";
        }
    }
}

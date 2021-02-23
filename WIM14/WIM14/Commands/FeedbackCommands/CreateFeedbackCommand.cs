using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;

namespace WIM14.Commands
{
    class CreateFeedbackCommand : Command
    {
        public CreateFeedbackCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters, database, factory)
        {
        }
        public override string Execute()
        {
            string title;
            string description;
            int rating;
            string teamName;
            string boardName;
            ITeam team;
            IBoard board;

            try
            {
                //TODO: Validations
                title = this.CommandParameters[0];
                description = this.CommandParameters[1];
                rating = int.Parse(this.CommandParameters[2]);
                teamName = this.CommandParameters[3];
                boardName = this.CommandParameters[4];

                team = this.Database.Teams.FirstOrDefault(t => t.Name == teamName);
                board = team.Boards.FirstOrDefault(b => b.Name == boardName);
            }
            catch 
            {
                throw new ArgumentException("Failed to parse CreateFeedback command parameters.");
            }
            if (team == null)
            {
                throw new ArgumentException($"Team with name {teamName} does not exist.");
            }

            if (board == null)
            {
                throw new ArgumentException($"Team with name {boardName} does not exist.");
            }

            IFeedback feedback = this.Factory.CreateFeedback(title, description, rating);
            board.AddWorkItem(feedback);
            this.Database.WorkItems.Add((IFeedback)feedback);
            return $"Feedback with ID: {feedback.Id} and Title: {feedback.Title} was created.";
        }
    }
}

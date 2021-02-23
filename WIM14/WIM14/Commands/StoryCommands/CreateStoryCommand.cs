using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class CreateStoryCommand : Command
    {
        public CreateStoryCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters, database, factory)
        {
        }
        public override string Execute()
        {
            string title;
            string description;
            Priority priority;
            Size size;
            string teamName;
            string boardName;
            ITeam team;
            IBoard board;

            try
            {
                //TODO: Validations
                title = this.CommandParameters[0];
                description = this.CommandParameters[1];
                priority = Enum.Parse<Priority>(this.CommandParameters[2], true);
                size = Enum.Parse<Size>(this.CommandParameters[3], true);
                teamName = this.CommandParameters[4];
                boardName = this.CommandParameters[5];

                team = this.Database.Teams.FirstOrDefault(t => t.Name == teamName);
                board = team.Boards.FirstOrDefault(b => b.Name == boardName);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateStory command parameters.");
            }
            if (team == null)
            {
                throw new ArgumentException($"Team with name {teamName} does not exist.");
            }

            if (board == null)
            {
                throw new ArgumentException($"Team with name {boardName} does not exist.");
            }
            IStory story = this.Factory.CreateStory(title, description, priority, size);

            this.Database.WorkItems.Add((IStory)story);

            return $"Story with ID: {story.Id} and Title: {story.Title} was created.";
        }
    }
}

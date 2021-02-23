using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class CreateStoryCommand : Command
    {
        public CreateStoryCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string title;
            string description;
            Priority priority;
            Size size;

            try
            {
                //TODO: Validations
                title = this.CommandParameters[0];
                description = this.CommandParameters[1];
                priority = Enum.Parse<Priority>(this.CommandParameters[2], true);
                size = Enum.Parse<Size>(this.CommandParameters[3], true);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateStory command parameters.");
            }

            IStory story = this.Factory.CreateStory(title, description, priority, size);

            this.Database.WorkItems.Add((IStory)story);

            return $"Bug with ID:{story.Id} and Title:{story.Title} was created.";
        }
    }
}

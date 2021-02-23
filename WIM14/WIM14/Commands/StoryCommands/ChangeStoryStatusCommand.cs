using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class ChangeStoryStatusCommand : Command
    {
        public ChangeStoryStatusCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters, database, factory)
        {
        }
        public override string Execute()
        {
            int id;
            IStory story;
            StoryStatus previouStatus;
            StoryStatus newStatus;
            try
            {
                //TODO: Validations
                id = int.Parse(this.CommandParameters[0]);
                story = this.Database.WorkItems.FirstOrDefault(s => s.Id == id) as IStory;
                newStatus = Enum.Parse<StoryStatus>(this.CommandParameters[1], true);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeStoryStatus command parameters.");
            }
            if (story == null)
            {
                throw new Exception($"No story was found with id {id}");
            }
            previouStatus = story.Status;
            story.Status = newStatus;

            return $"Status changed on Story with ID{story.Id} from {previouStatus} to {story.Status}";
        }
    }
}

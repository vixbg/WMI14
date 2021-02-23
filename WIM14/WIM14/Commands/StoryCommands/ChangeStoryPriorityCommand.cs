using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class ChangeStoryPriorityCommand : Command
    {
        public ChangeStoryPriorityCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters, database, factory)
        {
        }
        public override string Execute()
        {
            int id;
            IStory story;
            Priority previouPriority;
            Priority newPriority;
            try
            {
                //TODO: Validations
                id = int.Parse(this.CommandParameters[0]);
                story = this.Database.WorkItems.FirstOrDefault(s => s.Id == id) as IStory;
                newPriority = Enum.Parse<Priority>(this.CommandParameters[1], true);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeStoryPriority command parameters.");
            }
            if (story == null)
            {
                throw new Exception($"No story was found with id {id}");
            }
            previouPriority = story.Priority;
            story.Priority = newPriority;

            return $"Priority changed on Story with ID{story.Id} from {previouPriority} to {story.Priority}";
        }
    }
}

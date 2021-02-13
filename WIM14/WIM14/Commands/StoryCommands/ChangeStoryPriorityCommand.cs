using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class ChangeStoryPriorityCommand : Command
    {
        public ChangeStoryPriorityCommand(IList<string> commandParameters) : base(commandParameters)
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
                story = (IStory)this.Database.WorkItems.First(s => s.Id == id);
                newPriority = Enum.Parse<Priority>(this.CommandParameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeStoryPriority command parameters.");
            }
            previouPriority = story.Priority;
            story.Priority = newPriority;

            return $"Priority changed on Story with ID{story.Id} from {previouPriority} to {story.Priority}";
        }
    }
}

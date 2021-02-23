using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class ChangeStorySizeCommand : Command
    {
        public ChangeStorySizeCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            int id;
            IStory story;
            Size previouSize;
            Size newSize;
            try
            {
                //TODO: Validations for null
                id = int.Parse(this.CommandParameters[0]);
                story = this.Database.WorkItems.FirstOrDefault(s => s.Id == id) as IStory;
                newSize = Enum.Parse<Size>(this.CommandParameters[1], true);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeStorySize command parameters.");
            }

            if (story == null)
            {
                throw new Exception($"No story was found with id {id}");
            }
            previouSize = story.Size;
            story.Size = newSize;

            return $"Size changed on Story with ID{story.Id} from {previouSize} to {story.Size}";
        }
    }
}

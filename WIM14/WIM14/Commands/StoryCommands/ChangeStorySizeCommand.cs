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
                //TODO: Validations
                id = int.Parse(this.CommandParameters[0]);
                story = (IStory)this.Database.WorkItems.First(s => s.Id == id);
                newSize = Enum.Parse<Size>(this.CommandParameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeStorySize command parameters.");
            }
            previouSize = story.Size;
            story.Size = newSize;

            return $"Size changed on Story with ID{story.Id} from {previouSize} to {story.Size}";
        }
    }
}

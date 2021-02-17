using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Commands
{
    class ListWorkItemsCommand : Command
    {
        public ListWorkItemsCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }

        //list [BUG/STORY/FEEDBACK/ALL] [STATUS/ASSIGNEE] [Which Status/Assignee] [title/priority/severity/size/rating]
        public override string Execute()
        {
            var allowedTypes = new List<string>() { "bug", "story", "feedback" };
            var optionOne = new List<string>() { "status", "assignee" };
            var orderBy = new List<string>() { "title", "priority", "severity", "size", "rating" };
            string param1 = "all";
            string param2 = "status";
            Enum param3status = BugStatus.Active;
            string param3name = "";
            string param4 = "title";

            if (CommandParameters.Count > 0)
            {
                param1 = CommandParameters[0].ToLower();
            }
            if (CommandParameters.Count > 1)
            {
                param2 = CommandParameters[1].ToLower();
            }
            if (CommandParameters.Count > 2)
            {
                if (param2 == "status")
                {
                    param3status = (CommandParameters[0]) switch
                    {
                        "bug" => Enum.Parse<BugStatus>(CommandParameters[2]),
                        "story" => Enum.Parse<StoryStatus>(CommandParameters[2]),
                        "feedback" => Enum.Parse<FeedbackStatus>(CommandParameters[2]),
                        _ => throw new ArgumentException("Invalid Status.")
                    };
                }
                else if (param2 == "assignee")
                {
                    var assigneeFoud = this.Database.Members.ToList().FirstOrDefault(p => p.Name == CommandParameters[2]);
                    if ((assigneeFoud == null))
                    {
                        throw new ArgumentNullException("No assignee found with that name.");
                    }
                    param3name = assigneeFoud.Name;
                }
               
            }
            if (CommandParameters.Count > 3)
            {
                param4 = CommandParameters[3].ToLower();
            }

            var workItems = param1 switch
            {
                "bug"=> this.Database.WorkItems.Where(b => b.GetType().Name.ToLower() == "bug" ).ToList(),

                "story"=> this.Database.WorkItems.Where(s => s.GetType().Name.ToLower() == "story").ToList(),

                "feedback" => this.Database.WorkItems.Where(f => f.GetType().Name.ToLower() == "feedback").ToList(),

                "all" => this.Database.WorkItems.ToList(),

                _=> throw new ArgumentException("Invalid command parameter.")

            };

            workItems = param2 switch
            {
                "status" => workItems.Where(b => b.GetType().Name.ToLower() == "bug").ToList(),

                "assignee" => this.Database.WorkItems.Where(s => s.GetType().Name.ToLower() == "story").ToList(),

                _ => throw new ArgumentException("Invalid command parameter.")

            };




        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Commands
{
    class ListWorkItemsCommand : Command
    {
        public ListWorkItemsCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters, database, factory)
        {
        }

        //list [BUG/STORY/FEEDBACK/ALL] [STATUS/ASSIGNEE] [Which Status/Assignee] [title/priority/severity/size/rating]
        public override string Execute()
        {
            var allowedTypes = new List<string>() {"bug", "story", "feedback", "all"};
            var allowedSearchTypes = new List<string>() {"status", "assignee"};
            var allowedOrders = new List<string>() {"title", "priority", "severity", "size", "rating"};
            string type = "all";
            string searchType = "";
            string nameOrStatus = "";
            string orderBy = "title";

            if (CommandParameters.Count > 0)
            {
                type = CommandParameters[0].ToLower();
                if (!allowedTypes.Contains(type))
                {
                    throw new Exception($"Type {type} is not supported in the list command");
                }
            }

            if (CommandParameters.Count > 1)
            {
                searchType = CommandParameters[1].ToLower();
                if (!allowedSearchTypes.Contains(searchType))
                {
                    throw new Exception($"Search Type {searchType} is not supported in the list command");
                }
            }

            if (CommandParameters.Count > 2)
            {
                nameOrStatus = CommandParameters[2];
            }

            if (CommandParameters.Count > 3)
            {
                orderBy = CommandParameters[3].ToLower();
                if (!allowedOrders.Contains(orderBy))
                {
                    throw new Exception($"Order by {orderBy} is not supported in the list command");
                }
            }

            if (searchType == "status")
            {
                Enum status = (type) switch
                {
                    "bug" => Enum.Parse<BugStatus>(nameOrStatus, true),
                    "story" => Enum.Parse<StoryStatus>(nameOrStatus, true),
                    "feedback" => Enum.Parse<FeedbackStatus>(nameOrStatus, true),
                    _ => throw new ArgumentException("Invalid Status.")
                };
            }
            else if(searchType == "assignee")
            {
                var assigneeFound = this.Database.Members.ToList().FirstOrDefault(p => p.Name == nameOrStatus);
                if ((assigneeFound == null))
                {
                    throw new ArgumentException("No assignee found with that name.");
                }
            }

            var workItems = type switch
            {
                "bug"=> this.Database.WorkItems.Where(b => b.WorkItemType == WorkItemType.Bug).ToList(),

                "story"=> this.Database.WorkItems.Where(s => s.WorkItemType == WorkItemType.Story).ToList(),

                "feedback" => this.Database.WorkItems.Where(f => f.WorkItemType == WorkItemType.Feedback).ToList(),

                "all" => this.Database.WorkItems.ToList(),

                _=> throw new ArgumentException("Invalid command parameter.")

            };

            workItems = searchType switch
            {
                "status" => workItems.Where(i => i.StatusString == nameOrStatus ).ToList(),

                "assignee" => workItems.Where(i => 
                    (i is IBug bug && bug.Assignee.Name == nameOrStatus) || 
                    (i is IStory story && story.Assignee.Name == nameOrStatus)).ToList(),

                "" => workItems.ToList(),

                _ => throw new ArgumentException("Invalid command parameter.")
            };

            var finalList = orderBy switch
            {
                "title" => workItems.OrderBy(i => i.Title),
                "priority" => workItems.Where(i => i is IPriority).OrderBy(i => ((IPriority) i).Priority),
                "severity" => workItems.Where(i => i is IBug).OrderBy(i => ((IBug)i).Severity),
                "size" => workItems.Where(i => i is IStory).OrderBy(i => ((IStory)i).Size),
                "rating" => workItems.Where(i => i is IFeedback).OrderBy(i => ((IFeedback) i).Rating)
            };

            var sortedList = finalList.ToList();
            if (sortedList.Count == 0)
            {
                return "No items found with those parameters.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Sorted by [Type: {type}] and [Search Type: {searchType}] in [order: {orderBy}]");
            foreach (var item in sortedList)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}

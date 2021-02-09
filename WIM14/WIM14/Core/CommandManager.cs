using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands;
using WIM14.Commands.Contracts;
using WIM14.Core.Contracts;

namespace WIM14.Core
{
    class CommandManager : ICommandManager
    {
        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine
                .Trim()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = lineParameters[0];
            List<string> commandParameters = lineParameters.Skip(1).ToList();

            return commandLine switch
            {
                //board
                "createboard" => new CreateBoardCommand(commandParameters),
                "showboardactivity" => new ShowBoardActivityCommand(commandParameters),
                //bug
                "changebugpriority" => new ChangeBugPrioriyCommand(commandParameters),
                "changebugseverity" => new ChangeBugSeverityCommand(commandParameters),
                "changebugstatus" => new ChangeBugStatusCommand(commandParameters),
                "createbug" => new CreateBugCommand(commandParameters),
                //feedback
                "changefeedbackrating" => new ChangeFeedbackRatingCommand(commandParameters),
                "changefeedbackstatus" => new ChangeFeedbackStatusCommand(commandParameters),
                "createfeedback" => new CreateFeedbackCommand(commandParameters),
                //member
                "addmember" => new AddMemberCommand(commandParameters),
                "createmember" => new CreateMemberCommand(commandParameters),
                "showallmembers" => new ShowAllMembersCommand(commandParameters),
                "showmemberactivity" => new ShowMemberActivityCommand(commandParameters),
                //story
                "changestorypriority" => new ChangeStoryPriorityCommand(commandParameters),
                "changestorysize" => new ChangeStorySizeCommand(commandParameters),
                "changestorystatus" => new ChangeStoryStatusCommand(commandParameters),
                "createstory" => new CreateStoryCommand(commandParameters),
                //team
                "createteam" => new CreateTeamCommand(commandParameters),
                "showallteamboards" => new ShowAllTeamBoardsCommand(commandParameters),
                "showallteammembers" => new ShowAllTeamMembersCommand(commandParameters),
                "showallteams" => new ShowAllTeamsCommand(commandParameters),
                "showteamactivity" => new ShowTeamActivityCommand(commandParameters),
                //workitems
                "addcomment" => new AddCommentToWorkItemCommand(commandParameters),
                "assignworkitem" => new AssignWorkItemCommand(commandParameters),
                "listworkitems" => new ListWorkItemsCommand(commandParameters),
                "unassignworkitem" => new UnassignWorkItemCommand(commandParameters),



                _ => throw new InvalidOperationException("Command does not exist!")
            };


        }
    }
}

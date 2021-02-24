using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands;
using WIM14.Commands.Contracts;
using WIM14.Core.Contracts;

namespace WIM14.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WIM14.Core.Contracts.ICommandManager" />
    class CommandManager : ICommandManager
    {
        /// <summary>
        /// Parses the command.
        /// </summary>
        /// <param name="commandLine">The command line to parse.</param>
        /// <returns></returns>
        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine
                .Trim()
                .Split(" --", StringSplitOptions.RemoveEmptyEntries);

            string commandName = lineParameters[0];
            List<string> commandParameters = lineParameters.Skip(1).ToList();

            return commandName switch
            {
                //board
                "createboard" => new CreateBoardCommand(commandParameters, Database.Instance, Factory.Instance),
                "showboardactivity" => new ShowBoardActivityCommand(commandParameters, Database.Instance, Factory.Instance),
                //bug
                "changebugpriority" => new ChangeBugPriorityCommand(commandParameters, Database.Instance, Factory.Instance),
                "changebugseverity" => new ChangeBugSeverityCommand(commandParameters, Database.Instance, Factory.Instance),
                "changebugstatus" => new ChangeBugStatusCommand(commandParameters, Database.Instance, Factory.Instance),
                "createbug" => new CreateBugCommand(commandParameters, Database.Instance, Factory.Instance),
                //feedback
                "changefeedbackrating" => new ChangeFeedbackRatingCommand(commandParameters, Database.Instance, Factory.Instance),
                "changefeedbackstatus" => new ChangeFeedbackStatusCommand(commandParameters, Database.Instance, Factory.Instance),
                "createfeedback" => new CreateFeedbackCommand(commandParameters, Database.Instance, Factory.Instance),
                //member
                "addmember" => new AddMemberCommand(commandParameters, Database.Instance, Factory.Instance),
                "createmember" => new CreateMemberCommand(commandParameters, Database.Instance, Factory.Instance),
                "showallmembers" => new ShowAllMembersCommand(commandParameters, Database.Instance, Factory.Instance),
                "showmemberactivity" => new ShowMemberActivityCommand(commandParameters, Database.Instance, Factory.Instance),
                //story
                "changestorypriority" => new ChangeStoryPriorityCommand(commandParameters, Database.Instance, Factory.Instance),
                "changestorysize" => new ChangeStorySizeCommand(commandParameters, Database.Instance, Factory.Instance),
                "changestorystatus" => new ChangeStoryStatusCommand(commandParameters, Database.Instance, Factory.Instance),
                "createstory" => new CreateStoryCommand(commandParameters, Database.Instance, Factory.Instance),
                //team
                "createteam" => new CreateTeamCommand(commandParameters, Database.Instance, Factory.Instance),
                "showallteamboards" => new ShowAllTeamBoardsCommand(commandParameters, Database.Instance, Factory.Instance),
                "showallteammembers" => new ShowAllTeamMembersCommand(commandParameters, Database.Instance, Factory.Instance),
                "showallteams" => new ShowAllTeamsCommand(commandParameters, Database.Instance, Factory.Instance),
                "showteamactivity" => new ShowTeamActivityCommand(commandParameters, Database.Instance, Factory.Instance),
                //workitems
                "addcomment" => new AddCommentToWorkItemCommand(commandParameters, Database.Instance, Factory.Instance),
                "assignworkitem" => new AssignWorkItemCommand(commandParameters, Database.Instance, Factory.Instance),
                "list" => new ListWorkItemsCommand(commandParameters, Database.Instance, Factory.Instance),
                "unassignworkitem" => new UnassignWorkItemCommand(commandParameters, Database.Instance, Factory.Instance),
                //default
                _ => throw new InvalidOperationException("Command does not exist!")
            };
        }
    }
}

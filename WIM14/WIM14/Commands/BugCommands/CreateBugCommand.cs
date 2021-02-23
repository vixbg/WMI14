using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;
using WIM14.Models;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Commands
{
    class CreateBugCommand : Command
    {
        public CreateBugCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters,  database,  factory)
        {
        }
        public override string Execute()
        {
            string title;
            string description;
            List<string> stepsToReproduce;
            Priority priority;
            Severity severity;
            string teamName;
            string boardName;
            ITeam team;
            IBoard board;
            
            try
            {
                //TODO: Validations
                title = this.CommandParameters[0];
                description = this.CommandParameters[1];
                stepsToReproduce = this.CommandParameters[2].Split("|", StringSplitOptions.None).ToList();
                priority = Enum.Parse<Priority>(this.CommandParameters[3], true);
                severity = Enum.Parse<Severity>(this.CommandParameters[4], true);
                teamName = this.CommandParameters[5];
                boardName = this.CommandParameters[6];

                team = this.Database.Teams.FirstOrDefault(t => t.Name == teamName);
                board = team.Boards.FirstOrDefault(b => b.Name == boardName);
                                
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBug command parameters.");
            }

            if(team == null)
            {
                throw new ArgumentException($"Team with name {teamName} does not exist.");
            }

            if (board == null)
            {
                throw new ArgumentException($"Team with name {boardName} does not exist.");
            }

            IBug bug = this.Factory.CreateBug(title, description, stepsToReproduce, priority, severity);

            board.AddWorkItem(bug);

            this.Database.WorkItems.Add((IBug)bug);

            return $"Bug with ID: {bug.Id} and Title: {bug.Title} was created.";
        }
    }
}

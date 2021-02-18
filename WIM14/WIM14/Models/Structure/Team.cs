using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Core;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models
{
    public class Team : ITeam
    {
        private readonly List<IMember> members = new List<IMember>(); 
        private readonly List<IBoard> boards = new List<IBoard>();
        private string name;

        public Team(string newName)
        {
            this.Name = newName;
            this.Boards = boards;
            this.Members = members;
        }

        public string Name 
        {
            get => this.name;
            set
            {
                this.EnsureValidName(value);
                this.name = value;
            }
        }
        public List<IMember> Members { get; }

        public List<IBoard> Boards { get; }

        public void AddPerson(IMember newMember)
        {
            this.members.Add(newMember);
            this.members.Last().AssignedTeam = this.Name;
            this.members.Last().AddHistoryEntry($"Member was added to team {this.Name}."); 
        }

        public void AddBoard (IBoard newBoard)
        {
            this.boards.Add(newBoard);
            this.boards.Last().AddHistoryEntry($"Board was added to team {this.Name}.");
        }

        public string ShowTeamActivity()
        {
            List<IHistoryEntry> teamActivity = new List<IHistoryEntry>();

            foreach (var member in this.members)
            {
                teamActivity.AddRange(member.ActivityHistory);
            }

            if (teamActivity.Count < 1) 
            {
                return $"There is no team activity to show.";
            }

            List<IHistoryEntry> sortedList = teamActivity.OrderByDescending(historyEntry => historyEntry.Time).ToList();

            return string.Join(Environment.NewLine, sortedList); //TODO: make it pretty
        }

        public override string ToString()
        {
            return $"Team {this.Name} " +
                   $"Members: {this.Members.Select(member => member.Name)}" +
                   $"Boards: {this.Boards.Select(board => board.Name)}";
        }

        private void EnsureValidName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Please provide a non-empty name.");
            }
        }

    }
}

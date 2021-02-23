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
            if (!this.members.Contains(newMember))
            {
                newMember.AssignedTeam = this.Name;
                newMember.AddHistoryEntry($"{newMember.GetType().Name} {newMember.Name} was added to team {this.Name}.");
                this.members.Add(newMember);
            }
            else
            {
                throw new ArgumentException($"{newMember.GetType().Name} {newMember.Name} is already added to team {this.Name}.");
            }
        }

        public void AddBoard (IBoard newBoard)
        {
            if (!this.boards.Contains(newBoard))
            {
                newBoard.AddHistoryEntry($"{newBoard.GetType().Name} {newBoard.Name} was added to team {this.Name}.");
                this.boards.Add(newBoard);
            }
            else
            {
                throw new ArgumentException($"{newBoard.GetType().Name} {newBoard.Name} is already added to team {this.Name}.");
            }
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

            return string.Join(Environment.NewLine, sortedList); 
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team {this.Name} ");
            sb.AppendLine($"Members:");
            foreach (var member in this.members)
            {
                sb.AppendLine(member.Name);
            }
            sb.AppendLine($"Boards:");

            foreach (var board in this.boards)
            {
                sb.AppendLine(board.Name);
            }

            return sb.ToString().Trim();
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

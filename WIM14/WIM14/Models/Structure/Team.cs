using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;

namespace WIM14.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WIM14.Models.Contracts.ITeam" />
    public class Team : ITeam
    {
        private readonly List<IMember> members = new List<IMember>(); 
        private readonly List<IBoard> boards = new List<IBoard>();
        private string name;
        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class.
        /// </summary>
        /// <param name="newName">The name of the new team.</param>
        public Team(string newName)
        {
            this.Name = newName;
            this.Boards = boards;
            this.Members = members;
        }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name 
        {
            get => this.name;
            set
            {
                this.EnsureValidName(value);
                this.name = value;
            }
        }
        /// <summary>
        /// Gets the members.
        /// </summary>
        public List<IMember> Members { get; }
        /// <summary>
        /// Gets the boards.
        /// </summary>
        public List<IBoard> Boards { get; }
        /// <summary>
        /// Adds new member to the list of members in the team.
        /// </summary>
        /// <param name="newMember">The new member to add.</param>
        /// <exception cref="ArgumentException"></exception>
        public void AddPerson(IMember newMember)
        {
            if (!this.members.Contains(newMember))
            {
                newMember.AssignedTeam = this.Name;
                this.members.Add(newMember);
            }
            else
            {
                throw new ArgumentException($"{newMember.GetType().Name} {newMember.Name} is already added to team {this.Name}.");
            }
        }
        /// <summary>
        /// Adds new board to the list of boards in the team.
        /// </summary>
        /// <param name="newBoard">The new board to add.</param>
        /// <exception cref="ArgumentException"></exception>
        public void AddBoard (IBoard newBoard)
        {
            if (!this.boards.Contains(newBoard))
            {
                this.boards.Add(newBoard);
            }
            else
            {
                throw new ArgumentException($"{newBoard.GetType().Name} {newBoard.Name} is already added to team {this.Name}.");
            }
        }
        /// <summary>
        /// Shows the team activity.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
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
        /// <summary>
        /// Ensures if the name is valid.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <exception cref="ArgumentException">Please provide a non-empty name.</exception>
        private void EnsureValidName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Please provide a non-empty name.");
            }
        }

    }
}

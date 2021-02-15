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
        private readonly List<Member> members = new List<Member>(); 
        private readonly List<Board> boards = new List<Board>();
        private string name;

        public Team(string newName)
        {
            this.Name = newName;
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

        public void AddPerson(Member newMember)
        {
            this.members.Add(newMember);
            this.members.Last().AssignTeam(this.name);
            this.members.Last().AddHistoryEntry($"Member was added to team {this.Name}."); 
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

        private void EnsureValidName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Please provide a non-empty name.");
            }
        }

    }
}

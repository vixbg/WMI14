using System;
using System.Collections.Generic;
using WIM14.Core;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models
{
    public class Member : IMember
    {
        private const int MAX_LENGTH = 15;
        private const int MIN_LENGTH = 5;
        private readonly List<IWorkItem> workItems = new List<IWorkItem>(); 
        private readonly List<IHistoryEntry> activityHistory = new List<IHistoryEntry>();
        private string assignedTeam;

        public Member(string newName)
        {
            this.EnsureValidName(newName);
            this.Name = newName;
            this.AddHistoryEntry($"{this.GetType().Name} with name {this.Name} was created.");
        }
        public string Name
        {
            get;
        }

        public List<IHistoryEntry> ActivityHistory 
        {
            get => this.activityHistory;
        }

        
        public string AssignedTeam { 
            get => this.assignedTeam;

            set
            {
                if (this.assignedTeam is null)
                {
                    this.assignedTeam = value;
                }
                else
                {
                    throw new ArgumentException($"Member {this.Name} is already in another team.");
                }
            }
        }


        public void AssignWorkItem(IWorkItem item)
        {
            if(!this.workItems.Contains(item))
            {
                this.workItems.Add(item);
                this.AddHistoryEntry($"{item.GetType().Name} {item.Title} was assigned to member {this.Name}.");
            }
            else
            {
                throw new ArgumentException($"{item.GetType().Name} {item.Title} is already assigned to member {this.Name}.");
            }
        }

        public void UnassignWorkItem(IWorkItem item)
        {
            if(this.workItems.Contains(item))
            {
                this.workItems.Remove(item);
                this.AddHistoryEntry($"{item.GetType().Name} {item.Title} was unassigned from member {this.Name}.");
            }
            else
            {
                throw new ArgumentException($"{item.GetType().Name} {item.Title} was not found.");
            }
        }
        public override string ToString()
        {
            if(this.AssignedTeam == "")
            {
                return $"{this.GetType().Name} {this.Name} || Total work items: {this.workItems.Count} ";
            }
            else
            {
                return $"{this.GetType().Name} {this.Name} || Total work items: {this.workItems.Count} || Team {this.AssignedTeam}";
            }
        }
        public string ShowActivityHistory()
        {
            return string.Join(Environment.NewLine, this.activityHistory);
        }
        public void AddHistoryEntry(string desc)
        {
            this.activityHistory.Add(new HistoryEntry(desc));
        }
        private void EnsureValidName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Please provide a non-empty name.");
            }
            if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH) 
            {
                throw new ArgumentException("Please provide a name with length between 5 and 15 characters.");
            }
        }
    }
}

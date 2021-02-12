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
        //TODO: add workitem
        //TODO: add person to team naprimer da imame string team i metod ChangeTeam v koito logvame v koi team e dobaven? kogato dobavim member v team, vikame changeteam 
        private readonly List<IWorkItem> workItems = new List<IWorkItem>(); 
        private readonly List<IHistoryEntry> activityHistory = new List<IHistoryEntry>();

        public Member(string newName)
        {
            this.EnsureValidName(newName);
            this.Name = newName;
            this.Type = Type.Member;
            this.AddHistoryEntry($"{this.Type} with name {this.Name} was created.");
        }
        public string Name
        {
            get;
        }

        public Type Type
        {
            get;
        }

        public List<IHistoryEntry> ActivityHistory 
        {
            get => this.activityHistory;
        }

        public string ShowInfo() //TODO: ToString
        {
            return $"{this.Type} {this.Name} || Total work items: {this.workItems.Count} ";
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
            if (value.Length < 5 || value.Length > 15) //TODO: remove magic numbers
            {
                throw new ArgumentException("Please provide a name with length between 5 and 15 characters.");
            }
        }
    }
}

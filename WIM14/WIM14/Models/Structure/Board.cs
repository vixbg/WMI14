using System;
using System.Collections.Generic;
using WIM14.Core;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;

namespace WIM14.Models
{
    public class Board : IBoard
    {
        private const int MAX_LENGTH = 15;
        private const int MIN_LENGTH = 5;
        private readonly List<IWorkItem> workItems = new List<IWorkItem>(); 
        private readonly List<IHistoryEntry> activityHistory = new List<IHistoryEntry>();
        private string name;
        public Board(string newName)
        {
            this.Name = newName;
            this.AddHistoryEntry($"{this.GetType().Name} with name {this.Name} was created.");
        }
        public string Name 
        {
            get => this.name;
            set
            {
                this.EnsureValidName(value);
                if(this.name != null)
                {
                    this.AddHistoryEntry($"{this.GetType().Name} name was changed to {value}.");
                }
                this.name = value;
            }
        }
        public List<IWorkItem> WorkItems
        {
            get => this.workItems;
        }

        public List<IHistoryEntry> ActivityHistory
        {
            get => this.activityHistory;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Name} || Total work items: {this.workItems.Count} ";
        }
        public string ShowActivityHistory()
        {
            return string.Join(Environment.NewLine, this.activityHistory);
        }
        private void AddHistoryEntry(string desc)
        {
            this.activityHistory.Add(new HistoryEntry(desc));
        }

        public void AddWorkItem(IWorkItem item)
        {
            if(!this.workItems.Contains(item))
            {
                this.workItems.Add(item);
                this.AddHistoryEntry($"{item.GetType().Name} {item.Title} was added to board {this.Name}.");
            }
            else
            {
                throw new ArgumentException($"{item.GetType().Name} {item.Title} has already been added to board {this.Name}.");
            }
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

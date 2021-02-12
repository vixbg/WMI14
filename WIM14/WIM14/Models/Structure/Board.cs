using System;
using System.Collections.Generic;
using WIM14.Core;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models
{
    public class Board : IBoard
    {
        //TODO add workitem
        private readonly List<IWorkItem> workItems = new List<IWorkItem>(); 
        private readonly List<IHistoryEntry> activityHistory = new List<IHistoryEntry>();
        private string name;
        public Board(string newName)
        {
            this.Name = newName;
            this.Type = Type.Board;
            this.AddHistoryEntry($"{this.Type} with name {this.Name} was created.");
        }
        public string Name 
        {
            get => this.name;
            set
            {
                this.EnsureValidName(value);
                this.name = value;
                this.AddHistoryEntry($"{this.Type} name was changed to {value}.");
            }
        }

        public Type Type 
        {
            get;
        }

        public string ShowInfo() //TODO: ToString
        {
            return $"{this.Type} {this.Name} || Total work items: {this.workItems.Count} ";
        }
        public string ShowActivityHistory()
        {
            return string.Join(Environment.NewLine, this.activityHistory);
        }
        protected void AddHistoryEntry(string desc)
        {
            this.activityHistory.Add(new HistoryEntry(desc));
        }
        private void EnsureValidName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Please provide a non-empty name.");
            }
            if (value.Length < 5 || value.Length > 15) // TODO - remove magic numbers 
            {
                throw new ArgumentException("Please provide a name with length between 5 and 15 characters.");
            }
        }
    }
}

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
        //TODO add workitem //idk what whis is supposed to mean
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
                this.name = value;
                this.AddHistoryEntry($"{this.GetType().Name} name was changed to {value}.");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Name} || Total work items: {this.workItems.Count} ";
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

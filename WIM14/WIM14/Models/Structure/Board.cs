using System;
using System.Collections.Generic;
using WIM14.Core;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;

namespace WIM14.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WIM14.Models.Contracts.IBoard" />
    public class Board : IBoard
    {
        private const int MAX_LENGTH = 15;
        private const int MIN_LENGTH = 5;
        private readonly List<IWorkItem> workItems = new List<IWorkItem>(); 
        private readonly List<IHistoryEntry> activityHistory = new List<IHistoryEntry>();
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="newName">String between 5 and 15 chars</param>
        public Board(string newName)
        {
            this.Name = newName;
            this.AddHistoryEntry($"{this.GetType().Name} with name {this.Name} was created.");
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
                if(this.name != null)
                {
                    this.AddHistoryEntry($"{this.GetType().Name} name was changed to {value}.");
                }
                this.name = value;
            }
        }

        /// <summary>
        /// Gets the work items.
        /// </summary>
        public List<IWorkItem> WorkItems
        {
            get => this.workItems;
        }

        /// <summary>
        /// Gets the activity history.
        /// </summary>
        public List<IHistoryEntry> ActivityHistory
        {
            get => this.activityHistory;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Name} || Total work items: {this.workItems.Count} ";
        }

        /// <summary>
        /// Shows the activity history.
        /// </summary>
        /// <returns></returns>
        public string ShowActivityHistory()
        {
            return string.Join(Environment.NewLine, this.activityHistory);
        }

        /// <summary>
        /// Adds history entry.
        /// </summary>
        /// <param name="desc">String description.</param>
        private void AddHistoryEntry(string desc)
        {
            this.activityHistory.Add(new HistoryEntry(desc));
        }

        /// <summary>
        /// Adds work item to the board's list of workitems.
        /// </summary>
        /// <param name="item">WorkItem to add.</param>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Ensures if the name is valid.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <exception cref="ArgumentException">
        /// Please provide a non-empty name.
        /// or
        /// Please provide a name with length between 5 and 15 characters.
        /// </exception>
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

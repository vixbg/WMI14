using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Core;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Models.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="WIM14.Models.Contracts.IWorkItem" />
    /// <seealso cref="WIM14.Models.Contracts.IWorkItemStatus{T}" />
    public class WorkItem<T> : IWorkItem, IWorkItemStatus<T> where T : Enum 
    {
        private string title;
        private string description;
        private T status;
        private WorkItemType workItemType;
        private const int MinDescLength = 10;
        private const int MaxDescLength = 500;
        private const int MinTitleLength = 10;
        private const int MaxTitleLength = 50;
        private const string TitleType = "Title";
        private const string DescType = "Description";

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkItem{T}"/> class.
        /// </summary>
        /// <param name="title">String between 10 and 50 chars.</param>
        /// <param name="description">String between 10 and 500 chars.</param>
        public WorkItem(string title, string description, WorkItemType newtype)
        {
            this.Id = Database.Instance.WorkItems.Any() ? Database.Instance.WorkItems.Max(m => m.Id) + 1 : 0;
            this.History = new List<IHistoryEntry>();
            this.Comments = new List<IComment>();
            this.Title = title;
            this.Description = description;
            this.WorkItemType = newtype;
            AddHistoryItem($"Item with ID{this.Id} was created.");

        }

        public WorkItemType WorkItemType { get; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public List<IComment> Comments { get; set; }

        /// <summary>
        /// Gets or sets the history.
        /// </summary>
        /// <value>
        /// The history.
        /// </value>
        public List<IHistoryEntry> History { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// String title of workitem.
        /// </value>
        public string Title
        {
            get => title;
            set => title = EnsureValidString(value, MinTitleLength,MaxTitleLength, TitleType);
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get => description;
            set => description = EnsureValidString(value, MinDescLength, MaxDescLength, DescType);
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public T Status
        {
            get => this.status;

            set
            {
                AddHistoryItem($"Status changed from {this.status} to {value}");
                this.status = value;
            }
        }

        /// <summary>
        /// Returns the status as a string.
        /// </summary>
        /// <value>
        /// The status string.
        /// </value>
        public string StatusString => Status.ToString();

        /// <summary>
        /// Ensures if the string is valid.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum the value can be.</param>
        /// <param name="max">The maximum the value can be.</param>
        /// <param name="type">The type of object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public virtual string EnsureValidString(string value, int min, int max, string type)
        {
            if (value == null)
            {
                throw new ArgumentException($"{type} cannot be empty.");
            }
            if (value.Length < min || value.Length > max)
            {
                throw new ArgumentException($"{type} must be between {min} and {max} characters.");
            }

            return value;
        }

        /// <summary>
        /// Adds the history item with description to the list of history events.
        /// </summary>
        /// <param name="description">None-empty string.</param>
        protected void AddHistoryItem(string description)
        {
            this.History.Add(new HistoryEntry($"{GetType().Name.ToUpper()}:{description}"));
        }

        /// <summary>
        /// Returns the history of the workitem as a string.
        /// </summary>
        /// <returns></returns>
        public virtual string ViewHistory()
        {
            var sb = new StringBuilder(); 
            var entries = History.OrderByDescending(e => e.Time);
            foreach (var entry in entries)
            {
                sb.AppendLine(entry.ToString());
            }

            return sb.ToString();
        }
    }
}

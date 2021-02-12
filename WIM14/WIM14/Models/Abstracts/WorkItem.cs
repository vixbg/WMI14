using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIM14.Core;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;

namespace WIM14.Models.Abstracts
{
    class WorkItem<T> : IWorkItem, IWorkItemStatus<T> where T : Enum 
    {
        private readonly int id;
        private string title;
        private string description;
        private const int MinDescLength = 10;
        private const int MaxDescLength = 500;
        private const int MinTitleLength = 10;
        private const int MaxTitleLength = 50;
        private const string TitleType = "Title";
        private const string DescType = "Description";


        public WorkItem(string title, string description)
        {
            this.id = Database.Instance.WorkItems.Max(m => m.Id) + 1;
            this.History = new List<IHistoryEntry>();
            this.Comments = new List<IComment>();
            this.title = title;
            this.description = description;
            //TODO: Add history entry
            
        }

        public int Id => id;
        

        public List<IComment> Comments { get; set; }

        public List<IHistoryEntry> History { get; set; }

        public string Title
        {
            get => title;
            set => title = EnsureValidString(value, MinTitleLength,MaxTitleLength, TitleType);
        }

        public string Description
        {
            get => description;
            set => description = EnsureValidString(value, MinDescLength, MaxDescLength, DescType);
        }

        public T Status { get; protected set; }

        public virtual string EnsureValidString(string value, int min, int max, string type)
        {
            if (value.Length < min || value.Length > max)
            {
                throw new ArgumentException($"{type} must be between {min} and {max} characters.");
            }

            return value;
        }

        public virtual void AddHistoryItem(string description)
        {
            this.History.Add(new HistoryEntry(description));
        }

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

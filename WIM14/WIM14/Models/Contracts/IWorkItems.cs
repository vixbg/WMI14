using System;
using System.Collections.Generic;
using WIM14.Core;

namespace WIM14.Models.Contracts
{
    public interface IWorkItemStatus<T> where T : Enum
    {
        public T Status { get; }
    }

    public interface IWorkItem
    {
        public int Id { get; }
        public List<IComment> Comments { get; set; }
        public List<HistoryEntry> History { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

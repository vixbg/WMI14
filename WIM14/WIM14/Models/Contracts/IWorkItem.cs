using System;
using System.Collections.Generic;
using WIM14.Core;
using WIM14.Core.Contracts;

namespace WIM14.Models.Contracts
{
    public interface IWorkItemStatus<T> where T : Enum
    {
        public T Status { get; set; }
    }

    public interface IWorkItem
    {
        public int Id { get; }
        public List<IComment> Comments { get; set; }
        public List<IHistoryEntry> History { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StatusString { get; }
    }
}

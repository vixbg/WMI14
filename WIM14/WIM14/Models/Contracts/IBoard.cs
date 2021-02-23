using System.Collections.Generic;
using WIM14.Core.Contracts;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models.Contracts
{
    public interface IBoard
    {
        public string Name { get; set; }
        public List<IWorkItem> WorkItems { get; }
        public List<IHistoryEntry> ActivityHistory { get; }
        public string ShowActivityHistory();
        void AddHistoryEntry(string v);
        public void AddWorkItem(IWorkItem item);
    }
}

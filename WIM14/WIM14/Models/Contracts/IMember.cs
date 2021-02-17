using System.Collections.Generic;
using WIM14.Core;
using WIM14.Core.Contracts;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models.Contracts
{
    public interface IMember
    {
        public string Name { get; }
        public List<IHistoryEntry> ActivityHistory { get; }
        public string AssignWorkItem(IWorkItem item);
        public string UnassignWorkItem(IWorkItem item);
        public string ShowActivityHistory();
        public void AddHistoryEntry(string desc);


    }
}

using System.Collections.Generic;
using WIM14.Core.Contracts;

namespace WIM14.Models.Contracts
{
    public interface IMember
    {
        public string Name { get; }
        public List<IWorkItem> WorkItems { get; }
        public List<IHistoryEntry> ActivityHistory { get; }
        string AssignedTeam { get; set; }
        public void AssignWorkItem(IWorkItem item);
        public void UnassignWorkItem(IWorkItem item);
        public string ShowActivityHistory();

    }
}

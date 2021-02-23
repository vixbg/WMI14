using System.Collections.Generic;
using WIM14.Core;
using WIM14.Core.Contracts;
using Type = WIM14.Models.Enums.Type;

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

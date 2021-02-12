using System.Collections.Generic;
using WIM14.Models.Enums;

namespace WIM14.Models.Contracts
{
    public interface IBug : IWorkItem, IWorkItemStatus<BugStatus>
    {
        List<string> StepsToReproduce { get; }
        Priority Priority { get; }
        Severity Severity { get; }
        IMember Assignee { get; }
    }
}

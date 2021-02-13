using System.Collections.Generic;
using WIM14.Models.Enums;

namespace WIM14.Models.Contracts
{
    public interface IBug : IWorkItem, IWorkItemStatus<BugStatus>
    {
        List<string> StepsToReproduce { get; }
        Priority Priority { get; set; }
        Severity Severity { get; set; }
        IMember Assignee { get; }
    }
}

using System.Collections.Generic;
using WIM14.Models.Enums;

namespace WIM14.Models.Contracts
{
    public interface IBug : IWorkItem, IWorkItemStatus<BugStatus>, IPriority
    {
        List<string> StepsToReproduce { get; }
        Severity Severity { get; set; }
        IMember Assignee { get; }
    }
}

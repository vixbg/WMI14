using System.Collections.Generic;
using WIM14.Models.Enums;

namespace WIM14.Models.Contracts
{
    public interface IBug : IWorkItem, IWorkItemStatus<BugStatus>, IPriority, IAssignee
    {
        List<string> StepsToReproduce { get; }
        Severity Severity { get; set; }
        
    }
}

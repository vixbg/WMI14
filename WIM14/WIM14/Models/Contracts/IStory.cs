using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Enums;

namespace WIM14.Models.Contracts
{
    public interface IStory : IWorkItem, IWorkItemStatus<StoryStatus>, IPriority, IAssignee
    {
        Size Size { get; set; }
        
    }
}

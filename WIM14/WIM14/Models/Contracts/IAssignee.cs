using System;
using System.Collections.Generic;
using System.Text;

namespace WIM14.Models.Contracts
{
    public interface IAssignee
    {
        IMember Assignee { get; set; }
    }
}

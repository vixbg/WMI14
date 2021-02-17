using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Enums;

namespace WIM14.Models.Contracts
{
    public interface IPriority
    {
        Priority Priority { get; set; }
    }
}

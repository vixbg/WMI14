using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Contracts;

namespace WIM14.Core.Contracts
{
    public interface IHistoryEntry
    {
        public DateTime Time { get; }
        public string Description { get; }

    }
}

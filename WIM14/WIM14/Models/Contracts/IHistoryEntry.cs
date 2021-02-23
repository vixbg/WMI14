using System;

namespace WIM14.Core.Contracts
{
    public interface IHistoryEntry
    {
        public DateTime Time { get; }
        public string Description { get; }

    }
}

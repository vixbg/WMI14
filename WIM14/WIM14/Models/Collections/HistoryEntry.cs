using System;
using WIM14.Core.Contracts;

namespace WIM14.Core
{
    public class HistoryEntry : IHistoryEntry
    {
        public HistoryEntry(string description)
        {
            Time = DateTime.Now;
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public DateTime Time { get; }
        public string Description { get; }

        public override string ToString()
        {
            return $"[{this.Time.ToString("yyyyMMdd|HH:mm:ss.ffff")}] {this.Description}";
        }
    }
}

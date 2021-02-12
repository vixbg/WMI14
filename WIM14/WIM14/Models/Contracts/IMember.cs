﻿using System.Collections.Generic;
using WIM14.Core;
using WIM14.Core.Contracts;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models.Contracts
{
    public interface IMember
    {
        public string Name { get; }
        public Type Type { get; }
        public List<IHistoryEntry> ActivityHistory { get; }
        public string ShowInfo();
        public string ShowActivityHistory();
        public void AddHistoryEntry(string desc);


    }
}

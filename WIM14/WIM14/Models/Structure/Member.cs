using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Core;
using WIM14.Models.Contracts;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models
{
    class Member : IMember, IType
    {
        private Type _type;
        public int Id { get; set; }
        public string Name { get; set; } 
        public List<HistoryEntry> History { get; set; } 
        public Team Team { get; set; }

        Type IType.Type => _type;
    }
}

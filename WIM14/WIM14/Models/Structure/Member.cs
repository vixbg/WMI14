using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Contracts;

namespace WIM14.Models
{
    class Member : IMember
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public List<object> History { get; set; } // Change object to history;
        public Team Team { get; set; }
    }
}

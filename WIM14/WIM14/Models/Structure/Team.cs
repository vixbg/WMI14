using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Contracts;

namespace WIM14.Models
{
    class Team : ITeam
    {
        public int Id { get; set; }
        public List<Member> Members { get; set; }
        public List<Board> Boards { get; set; }
    }
}

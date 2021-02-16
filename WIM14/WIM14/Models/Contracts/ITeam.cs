using System;
using System.Collections.Generic;
using System.Text;

namespace WIM14.Models.Contracts
{
    public interface ITeam
    {
        public string Name { get; set; }
        public List<Member> Members { get; }
        public List<Board> Boards { get; }
        public void AddPerson(Member newMember);
        public void AddBoard(Board newBoard);
        public string ShowTeamActivity();
    }
}

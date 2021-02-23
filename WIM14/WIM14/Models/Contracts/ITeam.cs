using System.Collections.Generic;

namespace WIM14.Models.Contracts
{
    public interface ITeam
    {
        public string Name { get; set; }
        public List<IMember> Members { get; }
        public List<IBoard> Boards { get; }
        public void AddPerson(IMember newMember);
        public void AddBoard(IBoard newBoard);
        public string ShowTeamActivity();
    }
}

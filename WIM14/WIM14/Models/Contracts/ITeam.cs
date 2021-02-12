using System;
using System.Collections.Generic;
using System.Text;

namespace WIM14.Models.Contracts
{
    public interface ITeam
    {
        public string Name { get; set; }

        public void AddPerson(Member newMember);

        public string ShowTeamActivity();
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;
using WMI14.Models.Enums;
using System.Linq;

namespace WMI14.Tests.TeamTests
{

    [TestClass]
    public class RemoveItemFromBoard_Should
    {
        [TestMethod]
        public void RemoveIfItemIsContainedInTheBoard()
        {
            var testedTeam = new Team("testTeam");
            var testedBoard = new Board("testBoard", testedTeam);
            testedTeam.AddBoard(testedBoard);
            var bug1 = new Bug("randomBug1", "randomDescription", new List<string>(), Priority.High, BugSeverity.Major, BugStatus.Active);
            testedTeam.AddItemToBoard(bug1, testedBoard);

            Assert.IsTrue(testedBoard.WorkItems.Values.Contains(bug1));
            testedTeam.RemoveItemFromBoard(bug1, testedBoard);

            Assert.IsTrue(!testedBoard.WorkItems.Values.Contains(bug1));
        }

        [TestMethod]
        public void ThrowIfItemIsNotContainedInBoard()
        {
            var testedTeam = new Team("testTeam");
            var testedBoard = new Board("testBoard", testedTeam);
            testedTeam.AddBoard(testedBoard);
            var bug1 = new Bug("randomBug1", "randomDescription", new List<string>(), Priority.High, BugSeverity.Major, BugStatus.Active);

            Assert.ThrowsException<Exception>(() => testedTeam.RemoveItemFromBoard(bug1, testedBoard));

        }

        [TestMethod]
        public void ThrowIfBoardDoesNotContainItemButTeamDoes()
        {
            var testedTeam = new Team("testTeam");
            var testedBoard = new Board("testBoard", testedTeam);
            var testedBoard2 = new Board("testBoard", testedTeam);
            testedTeam.AddBoard(testedBoard2);
            var bug1 = new Bug("randomBug1", "randomDescription", new List<string>(), Priority.High, BugSeverity.Major, BugStatus.Active);
            testedTeam.AddItemToBoard(bug1, testedBoard2);

            Assert.ThrowsException<Exception>(() => testedTeam.RemoveItemFromBoard(bug1, testedBoard));

        }



    }
}

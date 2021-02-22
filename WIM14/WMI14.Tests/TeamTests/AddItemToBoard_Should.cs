using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Moq;
using WMI14.Models;
using WMI14.Models.Enums;

namespace WMI14.Tests.TeamTests
{
    [TestClass]
    public class AddItemToBoard_Should
    {
        [TestMethod]
        public void ThrowIfItemIsAlreadyContained()
        {
            var testedTeam = new Team("testTeam");
            var testedBoard = new Board("testBoard", testedTeam);
            testedTeam.AddBoard(testedBoard);
            var bug1 = new Bug("randomBug1", "randomDescription", new List<string>(), Priority.High, BugSeverity.Major, BugStatus.Active);

            testedTeam.AddItemToBoard(bug1, testedBoard);

            Assert.ThrowsException<Exception>(() => testedTeam.AddItemToBoard(bug1, testedBoard));
        }

        [TestMethod]
        public void CorrectlyAddItemToBoard()
        {
            var testedTeam = new Team("testTeam");
            var testedBoard = new Board("testBoard", testedTeam);
            testedTeam.AddBoard(testedBoard);
            var bug1 = new Bug("randomBug1", "randomDescription", new List<string>(), Priority.High, BugSeverity.Major, BugStatus.Active);

            testedTeam.AddItemToBoard(bug1, testedBoard);

            Assert.IsTrue(testedTeam.Boards.Values.Any(board => board.WorkItems.Values.Contains(bug1)));
        }

        [TestMethod]
        public void ThrowIfThereIsNoSuchBoard()
        {
            var testedTeam = new Team("testTeam");
            var testedBoard = new Board("testBoard", testedTeam); 
            var bug1 = new Bug("randomBug1", "randomDescription", new List<string>(), Priority.High, BugSeverity.Major, BugStatus.Active);

            Assert.ThrowsException<Exception>(() => testedTeam.AddItemToBoard(bug1, testedBoard));
        }





    }
}

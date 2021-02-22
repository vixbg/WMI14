using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMI14.Models;
using WMI14.Models.Contracts;
using Moq;
using WMI14.Models.Enums;

namespace WMI14.Tests.TeamTests
{
    [TestClass]
    public class GetWorkItemsByType_Should
    {
        [TestMethod]
        [DataRow("Bugg")]
        [DataRow("Storyy")]
        [DataRow("Feedbacl")]
        public void ThrowIfInvalidValueIsPassed(string type)
        {
            //Arrange
            string teamName = "RandomTeam";

            //Act
            var team = new Team(teamName);

            //Assert
            Assert.ThrowsException<ArgumentException>(() => team.GetWorkItemsByType(type));

        }

        [TestMethod]
        public void ReturnProperObjectsIfBoardIsNotNull()
        {
            var team = new Team("randomTeam");
            var board = new Board("boardName", team);
            team.AddBoard(board);
            var bug1 = new Bug("randomBug1", "randomDescription", new List<string>(), Priority.High, BugSeverity.Major, BugStatus.Active);
            board.AddWorkItem(bug1);

            Assert.AreEqual(bug1, team.GetWorkItemsByType("bug", board)[0]);

        }

        [TestMethod]
        public void ReturnProperObjectsIfBoardIsNull()
        {
            var team = new Team("randomTeam");
            var board = new Board("boardName", team);
            team.AddBoard(board);
            var bug1 = new Bug("randomBug1", "randomDescription", new List<string>(), Priority.High, BugSeverity.Major, BugStatus.Active);
            board.AddWorkItem(bug1);

            Assert.AreEqual(bug1, team.GetWorkItemsByType("bug")[0]);

        }

    }


}

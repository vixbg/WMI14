using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;
using System.Linq;

namespace WMI14.Tests.TeamTests
{
    [TestClass]
    public class AddBoard_Should
    {
        [TestMethod]
        public void ThrowIfBoardAlreadyExists()
        {
            var teamTested = new Team("teamName");
            var boardToAdd = new Board("boardName", teamTested);
            teamTested.AddBoard(boardToAdd);

            Assert.ThrowsException<Exception>(() => teamTested.AddBoard(boardToAdd));

        }

        [TestMethod]
        public void CorrectlyAddBoard()
        {
            var teamTested = new Team("teamName");
            var boardToAdd = new Board("boardName", teamTested);
            teamTested.AddBoard(boardToAdd);

            Assert.IsTrue(teamTested.Boards.Values.Contains(boardToAdd));
        }
    }
}

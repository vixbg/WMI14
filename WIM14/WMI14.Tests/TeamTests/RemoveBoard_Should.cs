using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;
using System.Linq;

namespace WMI14.Tests.TeamTests
{
    [TestClass]
    public class RemoveBoard_Should
    {

        [TestMethod]
        public void RemoveCorrectlyIfBoardExists()
        {
            var teamTested = new Team("teamName");
            var boardToAdd = new Board("boardName", teamTested);
            teamTested.AddBoard(boardToAdd);

            Assert.IsTrue(teamTested.Boards.Values.Contains(boardToAdd));
            teamTested.RemoveBoard(boardToAdd);
            Assert.IsTrue(!teamTested.Boards.Values.Contains(boardToAdd));


        }

        [TestMethod]
        public void ThrowIfNotSuchBoard()
        {
            var teamTested = new Team("teamName");
            var boardToTest = new Board("boardName", teamTested);

            Assert.ThrowsException<Exception>(() => teamTested.RemoveBoard(boardToTest));
        }

    }
}

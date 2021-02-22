using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Core;
using WMI14.Models;
using WMI14.Models.Contracts;

namespace WMI14.Tests.DatabaseTests
{
    [TestClass]
    public class GetBoard_Should
    {
        [TestMethod]
        public void GetBoardCorrectly()
        {
            // Arrange
            var database = new Database();
            var team = new Team("test_team");
            var board = new Board("test_board", team);

            // Act
            team.AddBoard(board);

            // Assert
            Assert.AreEqual(board, database.GetBoard(board.Name, team));

        }

        [TestMethod]
        public void GetBoardThrowsException()
        {
            // Arrange
            var database = new Database();
            var team = new Team("test_team");
            var board = new Board("test_board", team);
            var boardTwo = new Board("test_brd", team);

            // Act
            team.AddBoard(board);

            // Assert
            Assert.ThrowsException<ArgumentException>(() => database.GetBoard(boardTwo.Name, team));
        }


    }
}

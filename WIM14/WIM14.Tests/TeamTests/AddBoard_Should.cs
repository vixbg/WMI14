using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models;
using WIM14.Models.Contracts;

namespace WIM14.Tests.ModelsTests.TeamTests
{
    [TestClass]
    public class AddBoard_Should
    {
        [TestMethod]
        public void AddCorrectMember()
        {
            //Arrange
            var sut = new Team("Team14");
            var board = new Mock<IBoard>().Object;

            //Act
            sut.AddBoard(board);

            //Assert
            Assert.IsTrue(sut.Boards.Contains(board));
        }

        [TestMethod]
        public void Throw_When_MemberAlreadyExists()
        {
            //Arrange
            var sut = new Team("Team14");
            var board = new Mock<IBoard>().Object;
            sut.AddBoard(board);

            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => sut.AddBoard(board));
        }
    }
}

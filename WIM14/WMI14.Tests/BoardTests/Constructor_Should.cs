using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.BoardTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void AssignCorrectName()
        {
            // Arrange
            var expected = "Board";
            var team = new Mock<ITeam>().Object;

            // Act
            var sut = new Board(expected, team);

            // Assert
            Assert.AreEqual(sut.Name, expected);
        }

        [TestMethod]
        public void ThrowException_NameNull()
        {
            // Arrange
            string expected = null;
            var team = new Mock<ITeam>().Object;

            // Assert & Act
            Assert.ThrowsException<ArgumentException>(() => new Board(expected, team));
        }

        [TestMethod]
        public void ThrowException_NameBelowRange()
        {
            // Arrange
            string expected = new string('x',4);
            var team = new Mock<ITeam>().Object;

            // Assert & Act
            Assert.ThrowsException<ArgumentException>(() => new Board(expected, team));
        }
        [TestMethod]
        public void ThrowException_NameAboveRange()
        {
            // Arrange
            string expected = new string('x', 11);
            var team = new Mock<ITeam>().Object;

            // Assert & Act
            Assert.ThrowsException<ArgumentException>(() => new Board(expected, team));
        }
    }
}

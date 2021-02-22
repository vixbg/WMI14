using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Core;
using WMI14.Models.Contracts;

namespace WMI14.Tests.DatabaseTests
{
    [TestClass]
    public class AddTeam_Should
    {
        [TestMethod]
        public void AddTeamCorrectly()
        {
            // Arrange
            var database = new Database();
            var team = new Mock<ITeam>().Object;

            // Act
            database.AddTeam(team);

            // Assert
            Assert.AreEqual(team, database.Teams[0]);
        }

        [TestMethod]
        public void AddTeamThrowsException()
        {
            // Arrange
            var database = new Database();
            var team = new Mock<ITeam>().Object;

            // Act
            database.AddTeam(team);

            // Assert
            Assert.ThrowsException<Exception>(() => database.AddTeam(team));
        }
    }
}

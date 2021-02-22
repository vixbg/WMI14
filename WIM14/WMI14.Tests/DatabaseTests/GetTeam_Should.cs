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
    public class GetTeam_Should
    {
        [TestMethod]
        public void GetTeamCorrectly()
        {
            // Arrange
            string team1Name = "team_one";
            var team1 = new Mock<ITeam>();

            team1.SetupGet(member => member.Name).Returns(team1Name);

            var database = new Database();

            // Act
            database.AddTeam(team1.Object);

            // Assert
            Assert.AreEqual(team1.Object, database.GetTeam(team1Name));
        }
    }
}

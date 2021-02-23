using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models;

namespace WIM14.Tests.ModelsTests.MemberTests
{
    [TestClass]
    public class AssignedTeam_Should
    {
        [TestMethod]
        public void AssignCorrectValue()
        {
            //Arrange
            string assignedTeam = "Team14";
            var sut = new Member("Rumyana");
            //Act
            sut.AssignedTeam = assignedTeam;
            //Assert
            Assert.AreEqual(assignedTeam, sut.AssignedTeam);
        }

        [TestMethod]
        public void Throw_WhenAlreadySet()
        {
            //Arrange
            var sut = new Member("Rumyana");
            sut.AssignedTeam = "Team14";
            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => sut.AssignedTeam = "OtherTeam");
        }
    }
}

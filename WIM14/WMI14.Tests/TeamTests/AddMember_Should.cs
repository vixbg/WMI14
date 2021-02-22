using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using WMI14.Models.Contracts;
using WMI14.Models;
using System.Linq;

namespace WMI14.Tests.TeamTests
{
    [TestClass]
    public class AddMember_Should
    {
        [TestMethod]
        public void AddMemberProperlyIfNotExistingAlready()
        {
            //Arrange
            var memberAdded = new Mock<Member>("firstName", "lastName");

            //Act
            var teamAdding = new Team("testName");
            teamAdding.AddMember(memberAdded.Object);

            //Assert
            Assert.IsTrue(teamAdding.Members.Values.Contains(memberAdded.Object));
        }
        
        [TestMethod]
        public void ThrowIfMemberIsAlreadyInThatTeam()
        {
            //Arrange
            var memberAdded = new Mock<Member>("firstName", "lastName");

            //Act
            var teamAdding = new Team("testName");
            teamAdding.AddMember(memberAdded.Object);

            //Assert
            Assert.ThrowsException<Exception>(() => teamAdding.AddMember(memberAdded.Object));
        }

    }
}

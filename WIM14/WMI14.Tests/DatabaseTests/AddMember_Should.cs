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
    public class AddMember_Should
    {
        [TestMethod]
        public void AddMemberCorrectly()
        {
            // Arrange
            var database = new Database();
            var member = new Mock<IMember>().Object;

            // Act
            database.AddMember(member);

            // Assert
            Assert.AreEqual(member, database.Members[0]);
        }

        [TestMethod]
        public void AddMemberThrowsException()
        {
            // Arrange
            var database = new Database();
            var member = new Mock<IMember>().Object;

            // Act
            database.AddMember(member);

            // Assert
            Assert.ThrowsException<Exception>(() => database.AddMember(member));
        }
    }
}

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
    public class GetMember_Should
    {
        [TestMethod]
        public void GetMemberCorrecrly()
        {
            // Arrange
            var database = new Database();
            var member1 = new Member("alpha", "tethov");
            var member2 = new Member("zetha", "gamov");

            // Act
            database.AddMember(member2);
            database.AddMember(member1);

            // Assert
            Assert.AreEqual(member1, database.GetMember(member1.FirstName, member1.LastName));
        }

        [TestMethod]
        public void GetMemberThrowsException()
        {
            // Arrange
            var database = new Database();
            var member1 = new Member("alpha", "tethov");
            var member2 = new Member("zetha", "gamov");

            // Act
            database.AddMember(member2);

            // Assert
            Assert.ThrowsException<Exception>(() => database.GetMember(member1.FirstName, member1.LastName));
        }


    }
}

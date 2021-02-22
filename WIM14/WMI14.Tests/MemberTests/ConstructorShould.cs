using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;
using WMI14.Models.Contracts;
using WMI14.Models.Enums;

namespace WMI14.Tests.MemberTests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void AssignCorrectFirstAndLastNames()
        {
            // Arrange
            string firstName = "Zhelyazko";
            string lastName = "Blagoev";

            // Act
            var sut = new Member(firstName, lastName);

            // Assert
            Assert.AreEqual(firstName + lastName, sut.FirstName + sut.LastName);
        }

        [TestMethod]
        [DataRow(null,"Blagoev")]
        [DataRow("Yana", "Blagoev")]
        [DataRow("JoseLuisDiMariaElHernandes", "Blagoev")]
        [DataRow("Zhelyazko", null)]
        [DataRow(null, "Yana")]
        [DataRow(null, "JoseLuisDiMariaElHernandes")]
        public void ThrowExceptionsForFirstAndLastNames(string firstName, string lastName)
        {
            // Act & Assert
            Assert.ThrowsException<Exception>(() => new Member(firstName, lastName));

        }

    }
}

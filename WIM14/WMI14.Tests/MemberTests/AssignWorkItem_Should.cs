using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;
using WMI14.Models.Contracts;
using WMI14.Models.Enums;

namespace WMI14.Tests.MemberTests
{
    [TestClass]
    public class AssignWorkItem_Should
    {
        [TestMethod]
        public void AssignItemCorrectly()
        {
            // Arrange
            string firstName = "Zhelyazko";
            string lastName = "Blagoev";

            IWorkItem workItem = new Mock<IWorkItem>().Object;

            // Act
            var sut = new Member(firstName, lastName);
            sut.AssignWorkItem(workItem);

            // Assert
            Assert.AreEqual(workItem, sut.WorkItems[0]);
        }

        [TestMethod]
        public void AssignItemThrowsExceptionCorrectly()
        {
            // Arrange
            string firstName = "Zhelyazko";
            string lastName = "Blagoev";

            IWorkItem workItem = new Mock<IWorkItem>().Object;

            // Act
            var sut = new Member(firstName, lastName);
            sut.AssignWorkItem(workItem);

            // Assert
            Assert.ThrowsException<Exception>(() => sut.AssignWorkItem(workItem));
        }


    }
}

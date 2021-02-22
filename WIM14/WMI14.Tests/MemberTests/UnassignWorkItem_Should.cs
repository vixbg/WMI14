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
    public class UnassignWorkItem_Should
    {
        [TestMethod]
        public void UnassignItemCorrectly()
        {
            // Arrange
            string firstName = "Zhelyazko";
            string lastName = "Blagoev";

            IWorkItem workItem = new Mock<IWorkItem>().Object;

            // Act
            var sut = new Member(firstName, lastName);
            sut.AssignWorkItem(workItem);
            sut.UnassignWorkItem(workItem);

            // Assert
            Assert.AreEqual(0, sut.WorkItems.Count);
        }


        [TestMethod]
        public void UnassignItemThrowsExceptionCorrectly()
        {
            // Arrange
            string firstName = "Zhelyazko";
            string lastName = "Blagoev";

            IWorkItem workItem = new Mock<IWorkItem>().Object;

            // Act
            var sut = new Member(firstName, lastName);
            sut.AssignWorkItem(workItem);
            sut.UnassignWorkItem(workItem);

            // Assert
            Assert.ThrowsException<Exception>(() => sut.UnassignWorkItem(workItem));
        }

    }
}

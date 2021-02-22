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
    public class AddWorkItem_Should
    {
        [TestMethod]
        public void AddWorkItemCorrectly()
        {
            // Arrange
            var database = new Database();
            var workItem = new Mock<IWorkItem>().Object;

            // Act
            database.AddWorkItem(workItem);

            // Assert
            Assert.AreEqual(workItem, database.WorkItems[0]);
        }

        [TestMethod]
        public void AddWorkItemThrowsException()
        {
            // Arrange
            var database = new Database();
            var workItem = new Mock<IWorkItem>().Object;

            // Act
            database.AddWorkItem(workItem);

            // Assert
            Assert.ThrowsException<Exception>( () => database.AddWorkItem(workItem));

        }

    }
}

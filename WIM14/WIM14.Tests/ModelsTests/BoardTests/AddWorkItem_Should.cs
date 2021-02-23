using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models;
using WIM14.Models.Contracts;

namespace WIM14.Tests.ModelsTests.BoardTests
{
    [TestClass]
    public class AddWorkItem_Should
    {
        [TestMethod]
        public void AssignCorrectValue()
        {
            //Arrange
            string name = "WIM14Board";

            IWorkItem item = new Mock<IWorkItem>().Object;

            //Act
            var sut = new Board(name);
            sut.AddWorkItem(item);

            //Assert
            Assert.IsTrue(sut.WorkItems.Contains(item));
        }

        [TestMethod]
        public void Throw_When_ItemAlreadyExists()
        {
            //Arrange
            string name = "WIM14WorkItem";

            IWorkItem item = new Mock<IWorkItem>().Object;

            var sut = new Board(name);
            sut.AddWorkItem(item);

            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => sut.AddWorkItem(item));
        }
    }
}

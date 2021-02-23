using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models;
using WIM14.Models.Contracts;

namespace WIM14.Tests.ModelsTests.MemberTests
{
    [TestClass]
    public class UnassignWorkItem_Should
    {
        [TestMethod]
        public void AssignCorrectValue()
        {
            //Arrange
            string name = "Rumyana";

            IWorkItem item = new Mock<IWorkItem>().Object;

            var sut = new Member(name);
            sut.AssignWorkItem(item);

            //Act
            sut.UnassignWorkItem(item);

            //Assert
            Assert.IsTrue(!sut.WorkItems.Contains(item));
        }

        [TestMethod]
        public void Throw_When_ItemDoesNotExist()
        {
            //Arrange
            string name = "Rumyana";

            IWorkItem item = new Mock<IWorkItem>().Object;

            var sut = new Member(name);

            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => sut.UnassignWorkItem(item));
        }
    }
}

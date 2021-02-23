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
    public class AssignWorkItem_Should
    {
        [TestMethod]
        public void AssignCorrectValue()
        {
            //Arrange
            string name = "Rumyana";

            IWorkItem item = new Mock<IWorkItem>().Object;

            //Act
            var sut = new Member(name);
            sut.AssignWorkItem(item);

            //Assert
            Assert.IsTrue(sut.WorkItems.Contains(item));
        }

        [TestMethod]
        public void Throw_When_ItemAlreadyExists()
        {
            //Arrange
            string name = "Rumyana";

            IWorkItem item = new Mock<IWorkItem>().Object;

            var sut = new Member(name);
            sut.AssignWorkItem(item);

            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => sut.AssignWorkItem(item));
        }
    }
}

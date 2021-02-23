using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models;

namespace WIM14.Tests.ModelsTests.MemberTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Constructor_Should_AssignCorrectValue()
        {
            //Arrange
            string name = "Rumyana";

            //Act
            var sut = new Member(name);

            //Assert
            Assert.AreEqual(name, sut.Name);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("Anna")]
        [DataRow("Joseph Francis Tribbiani Jr")]
        [DataRow("")]
        public void Constructor_Should_ThrowException(string name)
        {
            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => new Member(name));
        }
    }
}

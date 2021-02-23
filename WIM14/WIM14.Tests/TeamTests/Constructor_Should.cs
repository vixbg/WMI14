using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models;

namespace WIM14.Tests.ModelsTests.TeamTests
{

    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Constructor_Should_AssignCorrectValue()
        {
            //Arrange
            string name = "Team14";

            //Act
            var sut = new Team(name);

            //Assert
            Assert.AreEqual(name, sut.Name);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void Constructor_Should_ThrowException(string name)
        {
            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => new Team(name));
        }

    }

}

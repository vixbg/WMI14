using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models;

namespace WIM14.Tests.ModelsTests.TeamTests
{
    [TestClass]
    public class Name_Should
    {
        [TestMethod]
        public void SetCorrectValue()
        {
            //Arrange
            string name = "Team14";
            var sut = new Team("DefaultName");

            //Act
            sut.Name = name;

            //Assert
            Assert.AreEqual(name, sut.Name);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void ThrowException(string name)
        {
            //Arrange
            var sut = new Team("Team14");

            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Name = name);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models;

namespace WIM14.Tests.ModelsTests.BoardTests
{
    [TestClass]
    public class Name_Should
    {
        [TestMethod]
        public void SetCorrectValue()
        {
            //Arrange
            string name = "WIM14Board";
            var sut = new Board("SomeName");

            //Act
            sut.Name = name;

            //Assert
            Assert.AreEqual(name, sut.Name);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("name")]
        [DataRow("VeryVeryLongName")]
        public void ThrowException(string name)
        {
            //Arrange
            var sut = new Board("WIM14Board");

            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Name = name);
        }
    }
}

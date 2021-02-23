using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models;

namespace WIM14.Tests.ModelsTests.MemberTests
{
    [TestClass]
    public class AddHistoryEntry_Should
    {
        [TestMethod]
        public void AddCorrectMessage()
        {
            //Arrange
            var sut = new Member("Rumyana"); //here we add one
            string message = "Testing.";

            //Act
            sut.AddHistoryEntry(message); //adding the second

            //Assert
            Assert.AreEqual(message, sut.ActivityHistory[1].Description);
        }
    }
}

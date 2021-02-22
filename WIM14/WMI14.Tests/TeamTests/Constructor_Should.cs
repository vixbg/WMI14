using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMI14.Models;

namespace WMI14.Tests.TeamTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ConstructProperlyIfProperValuesArePassed() 
        {
            //Arrange
            string name = "RandomName";

            //Act
            var team = new Team(name);

            //Assert
            Assert.AreEqual(name, team.Name, "Constructor name doesn't match the name expected by this test");
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")] //51a's
        public void ThrowErrorWhenInvalidNameIsPassed(string name)
        {
            //Arrange
            string teamName = name;

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Team(name));
        }



    }
}

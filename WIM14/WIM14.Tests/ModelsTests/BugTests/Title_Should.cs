using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WIM14.Core.Contracts;
using WIM14.Models;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Tests.ModelsTests.BugTests
{
    [TestClass]
    public class Title_Should
    {
        [TestMethod]
        public void SetCorrectValue()
        {
            // Arrange
            var title = "Random bug";
            var description = "Description of bug";
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            var priority = Priority.High;
            var expected = Severity.Critical;
            var newTitle = "ValidTitle";

            // Act
            var sut = new Bug(title, description, steps, priority, expected);
            sut.Title = newTitle;

            //Assert
            Assert.AreEqual(newTitle, sut.Title);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("name")]
        [DataRow("arbitrium arbitror architecto arcu ardore arguerent ars")]
        public void ThrowException(string newTitle)
        {
            // Arrange
            var title = "Random bug";
            var description = "Description of bug";
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            var priority = Priority.High;
            var expected = Severity.Critical;
            
            // Act
            var sut = new Bug(title, description, steps, priority, expected);

            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Title = newTitle);
        }
    }
}


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

namespace WIM14.Tests.ModelsTests.StoryTests
{
    [TestClass]
    public class Title_Should
    {
        [TestMethod]
        public void SetCorrectValue()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.NotDone;
            Priority priority = Priority.High;
            Size size = Size.Large;
            var newTitle = "ValidTitle";

            // Act
            var sut = new Story(title, description, priority, size);
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
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.NotDone;
            Priority priority = Priority.High;
            Size size = Size.Large;

            // Act
            var sut = new Story(title, description, priority, size);

            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Title = newTitle);
        }
    }
}


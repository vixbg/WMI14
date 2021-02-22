using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;
using WMI14.Models.Contracts;
using WMI14.Models.Enums;

namespace WMI14.Tests.StoryTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void AssignCorrectTitle()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.Done;
            Priority priority = Priority.High;
            StorySize size = StorySize.Large;

            // Act
            var sut = new Story(title, description, status, priority, size);

            // Assert
            Assert.AreEqual(title, sut.Title);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("aaaa")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ThrowWrongTitleException(string title)
        {
            // Arrange
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.Done;
            Priority priority = Priority.High;
            StorySize size = StorySize.Large;

            // Act & Assert
            Assert.ThrowsException<Exception>(() => new Story(title, description, status, priority, size));
        }

        [TestMethod]
        public void AssignCorrectDescr()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.Done;
            Priority priority = Priority.High;
            StorySize size = StorySize.Large;

            // Act
            var sut = new Story(title, description, status, priority, size);

            // Assert
            Assert.AreEqual(description, sut.Description);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("aaaa")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ThrowWrongDescrException(string description)
        {
            // Arrange
            string title = "best_story";
            StoryStatus status = StoryStatus.Done;
            Priority priority = Priority.High;
            StorySize size = StorySize.Large;

            // Act & Assert
            Assert.ThrowsException<Exception>(() => new Story(title, description, status, priority, size));
        }

    }
}

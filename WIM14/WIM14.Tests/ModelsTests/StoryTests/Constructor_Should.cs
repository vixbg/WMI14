using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Tests.ModelsTests.StoryTests
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
            StoryStatus status = StoryStatus.NotDone;
            Priority priority = Priority.High;
            Size size = Size.Large;

            // Act
            var sut = new Story(title, description, priority, size);

            // Assert
            Assert.AreEqual(title, sut.Title);
        }

        [TestMethod]
        public void AssignCorrectDescription()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.Done;
            Priority priority = Priority.High;
            Size size = Size.Large;

            // Act
            var sut = new Story(title, description, priority, size);

            // Assert
            Assert.AreEqual(description, sut.Description);
        }

        [TestMethod]
        public void AssignCorrectSize()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.Done;
            Priority priority = Priority.High;
            Size size = Size.Large;

            // Act
            var sut = new Story(title, description, priority, size);

            // Assert
            Assert.AreEqual(size, sut.Size);
        }

        [TestMethod]
        public void AssignCorrectStatus()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.NotDone;
            Priority priority = Priority.High;
            Size size = Size.Large;

            // Act
            var sut = new Story(title, description, priority, size);

            // Assert
            Assert.AreEqual(status, sut.Status);
        }

        [TestMethod]
        public void AssignCorrectPriority()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.Done;
            Priority priority = Priority.High;
            Size size = Size.Large;

            // Act
            var sut = new Story(title, description, priority, size);

            // Assert
            Assert.AreEqual(priority, sut.Priority);
        }

    }
}

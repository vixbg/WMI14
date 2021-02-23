using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Tests.ModelsTests.FeedbackTests
{
    [TestClass]
    public class Constructor_Should
    {

        [TestMethod]
        public void AssignCorrectTitle()
        {
            // Arrange
            var expected = "Random feedback";
            var description = "Description of feedback";
            var rating = 3;

            // Act
            var sut = new Feedback(expected, description, rating);

            // Assert
            Assert.AreEqual(expected, sut.Title);
        }

        [TestMethod]
        public void AssignCorrectDescription()
        {
            // Arrange
            var title = "Random feedback";
            var expected = "Descriptionoffeedback";
            var rating = 3;

            // Act
            var sut = new Feedback(title, expected, rating);

            // Assert
            Assert.AreEqual(expected, sut.Description);
        }

        [TestMethod]
        public void AssignCorrectRating()
        {
            // Arrange
            var title = "Random feedback";
            var description = "Description of feedback";
            var expected = 3;
            

            // Act
            var sut = new Feedback(title, description, expected);

            // Assert
            Assert.AreEqual(expected, sut.Rating);
        }

        [TestMethod]
        public void AssignCorrectStatus()
        {
            // Arrange
            var title = "Random feedback";
            var description = "Description of feedback";
            var rating = 3;
            var expected = FeedbackStatus.New;

            // Act
            var sut = new Feedback(title, description, rating);

            // Assert
            Assert.AreEqual(expected, sut.Status);
        }

    }
}

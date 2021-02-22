using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;
using WMI14.Models.Enums;

namespace WMI14.Tests.FeedbackTests
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
            var status = FeedbackStatus.New;

            // Act
            var sut = new Feedback(expected, description, rating, status);

            // Assert
            Assert.AreEqual(expected, sut.Title);
        }

        [TestMethod]
        public void AssignCorrectDescription()
        {
            // Arrange
            var title = "Random feedback";
            var expected = "Description of feedback";
            var rating = 3;
            var status = FeedbackStatus.New;

            // Act
            var sut = new Feedback(title, expected, rating, status);

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
            var status = FeedbackStatus.New;

            // Act
            var sut = new Feedback(title, description, expected, status);

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
            var sut = new Feedback(title, description, rating, expected);

            // Assert
            Assert.AreEqual(expected, sut.Status);
        }

        [TestMethod]
        public void ThrowWhenTitleNull() 
        {
            string title = null;
            var description = "Description of feedback";
            var rating = 3;
            var status = FeedbackStatus.New;

            // Act & Assert
            Assert.ThrowsException<Exception>(() => new Feedback(title, description, rating, status));
        }

        [TestMethod]
        public void ThrowWhenTitleIsShort() 
        {
            string title = new string('x', 9);
            var description = "Description of feedback";
            var rating = 3;
            var status = FeedbackStatus.New;

            // Act & Assert
            Assert.ThrowsException<Exception>(() => new Feedback(title, description, rating, status));
        }
        [TestMethod]
        public void ThrowWhenTitleIsLong()
        {
            string title = new string('x', 51);
            var description = "Description of feedback";
            var rating = 3;
            var status = FeedbackStatus.New;

            // Act & Assert
            Assert.ThrowsException<Exception>(() => new Feedback(title, description, rating, status));
        }

        [TestMethod]
        public void ThrowWhenDescriptionIsNull()
        {
            // Arrange
            var title = "Random feedback";
            string description = null;
            var rating = 3;
            var status = FeedbackStatus.New;

            // Act & Assert
            Assert.ThrowsException<Exception>(() => new Feedback(title, description, rating, status));
        }

        [TestMethod]
        public void ThrowWhenDescriptionIsShort()
        {
            // Arrange
            var title = "Random feedback";
            string description = new string('x', 9);
            var rating = 3;
            var status = FeedbackStatus.New;

            // Act & Assert
            Assert.ThrowsException<Exception>(() => new Feedback(title, description, rating, status));

        }

        [TestMethod]
        public void ThrowWhenDescriptionIsLong()
        {
            // Arrange
            var title = "Random feedback";
            string description = new string('x', 501);
            var rating = 3;
            var status = FeedbackStatus.New;

            // Act & Assert
            Assert.ThrowsException<Exception>(() => new Feedback(title, description, rating, status));
        }
    }
}

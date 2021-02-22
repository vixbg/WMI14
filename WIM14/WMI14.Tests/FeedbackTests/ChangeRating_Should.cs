using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;
using WMI14.Models.Enums;

namespace WMI14.Tests.FeedbackTests
{
    [TestClass]
    public class ChangeRating_Should
    {
        [TestMethod]
        public void ChangeRatingProperly()
        {
            // Arrange
            var title = "Random feedback";
            var description = "Description of feedback";
            var rating = 3;
            var status = FeedbackStatus.New;

            // Act
            var sut = new Feedback(title, description, rating, status);
            sut.ChangeRating(2);

            // Assert
            Assert.AreEqual(2, sut.Rating);
        }

        [TestMethod]
        public void ChangeRatingAtAll()
        {
            // Arrange
            var expected = "Random feedback";
            var description = "Description of feedback";
            var rating = 3;
            var status = FeedbackStatus.New;

            // Act
            var sut = new Feedback(expected, description, rating, status);
            sut.ChangeRating(2);

            // Assert
            Assert.AreNotEqual(3, sut.Rating);
        }

        

        [TestMethod]
        [DataRow(-1)]
        [DataRow(6)]
        public void ThrowWhenMoreThanFiveOrLessThanOne(int rating)
        {
            // Arrange
            var ratingInit = 3;
            var expected = "Random feedback";
            var description = "Description of feedback";
            var status = FeedbackStatus.New;

            // Act
            var sut = new Feedback(expected, description, ratingInit, status);

            // Assert
            Assert.ThrowsException<ArgumentException>(() => sut.ChangeRating(rating));
        }
    }
}

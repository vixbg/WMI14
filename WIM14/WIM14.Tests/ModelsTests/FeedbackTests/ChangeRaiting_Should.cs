using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Tests.ModelsTests.FeedbackTests
{
    [TestClass]
    public class ChangeRating_Should
    {
        [TestMethod]
        public void ChangeRatingSuccessfully()
        {
            // Arrange
            var title = "Random feedback";
            var description = "Description of feedback";
            var rating = 3;
            var expected = 5;
            

            // Act
            var sut = new Feedback(title, description, rating);
            sut.Rating = expected;

            // Assert
            Assert.AreEqual(sut.Rating, expected);
        }
    }
}
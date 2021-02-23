using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Tests.ModelsTests.FeedbackTests
{
    [TestClass]
    public class ChangeStatus_Should
    {
        [TestMethod]
        public void ChangeStatusSuccessfully()
        {
            // Arrange
            var title = "Random feedback";
            var description = "Description of feedback";
            var rating = 3;
            FeedbackStatus expected = FeedbackStatus.Scheduled;
            

            // Act
            var sut = new Feedback(title, description, rating);
            sut.Status = expected;

            // Assert
            Assert.AreEqual(sut.Status, expected);
        }
    }
}

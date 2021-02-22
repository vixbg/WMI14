using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;
using WMI14.Models.Enums;

namespace WMI14.Tests.FeedbackTests
{
    [TestClass]
    public class ChangeStatus_Should
    {
        [TestMethod]
        public void ChangeStatusProperly()
        {
            // Arrange
            var title = "Random feedback";
            var description = "Description of feedback";
            var rating = 3;
            var status = FeedbackStatus.New;

            // Act
            var sut = new Feedback(title, description, rating, status);
            sut.ChangeStatus(FeedbackStatus.Scheduled);

            // Assert
            Assert.AreEqual(FeedbackStatus.Scheduled, sut.Status);
        }

        [TestMethod]
        public void ChangeStatusAtAll()
        {
            // Arrange
            var expected = "Random feedback";
            var description = "Description of feedback";
            var rating = 3;
            var status = FeedbackStatus.New;

            // Act
            var sut = new Feedback(expected, description, rating, status);
            sut.ChangeStatus(FeedbackStatus.Scheduled);

            // Assert
            Assert.AreNotEqual(FeedbackStatus.New, sut.Status);
        }

    }
}

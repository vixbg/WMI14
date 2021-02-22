using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;
using WMI14.Models.Enums;

namespace WMI14.Tests.FeedbackTests
{
    [TestClass]
    public class ToString_Should
    {
        [TestMethod]
        public void PrintProperInfo() 
        {
            //Arrange
            var title = "Random feedback";
            var description = "Description of feedback";
            var rating = 3;
            var status = FeedbackStatus.New;

            // Act
            var feedbackItem = new Feedback(title, description, rating, status);
            var sb = new StringBuilder();
            sb.AppendLine($"Feedback Item");
            sb.AppendLine($"Title: {title}");
            sb.AppendLine($"Description: {description}");
            sb.AppendLine($"Item ID: {feedbackItem.ID}");
            sb.AppendLine($"Comments: No comments yet");
            sb.AppendLine($"Rating: {rating}");
            sb.AppendLine($"Status: {status}");
            sb.AppendLine("*************************");

            var sut = feedbackItem.ToString();

            //Assert
            Assert.AreEqual(sb.ToString().Trim(), sut);
        }
    }
}

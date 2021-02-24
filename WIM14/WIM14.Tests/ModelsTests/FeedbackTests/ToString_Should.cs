using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WIM14.Models;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Tests.ModelsTests.FeedbackTests
{
    [TestClass]
    public class ToString_Should
    {
        [TestMethod]
        public void PrintProperInfo()
        {
            // Arrange
            var title = "Random feedback";
            var description = "Description of feedback";
            var rating = 3;
            var newTitle = "ValidTitle";

            // Act
            var feedback = new Feedback(title, description, rating);

            var sb = new StringBuilder();
            sb.AppendLine($"{feedback.WorkItemType} ----");
            sb.AppendLine($"ID: {feedback.Id}");
            sb.AppendLine($"Title: {feedback.Title}");
            sb.AppendLine($"Description: {feedback.Description}");
            sb.AppendLine(feedback.Rating == 1 ? $"Rating: {feedback.Rating} star." : $"Rating: {feedback.Rating} stars.");
            feedback.Comments.ForEach(c => sb.AppendLine($"Comments: {c}"));
            var sut = feedback.ToString();

            //Assert
            Assert.AreEqual(sb.ToString().Trim(), sut);
        }
        
    }
}

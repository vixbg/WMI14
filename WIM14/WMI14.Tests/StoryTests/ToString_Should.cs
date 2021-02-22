using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;
using WMI14.Models.Contracts;
using WMI14.Models.Enums;

namespace WMI14.Tests.StoryTests
{
    [TestClass]
    public class ToString_Should
    {
        [TestMethod]
        public void ToStringPrintsCorrectMessageNoAssignee()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.Done;
            Priority priority = Priority.High;
            StorySize size = StorySize.Large;

            // Act
            var story = new Story(title, description, status, priority, size);

            var sb = new StringBuilder();
            sb.AppendLine($"Story Item");
            sb.AppendLine($"Title: {title}");
            sb.AppendLine($"Description: {description}");
            sb.AppendLine($"Item ID: {story.ID}");
            sb.AppendLine($"Comments: No comments yet");
            sb.AppendLine($"Status: {status}");
            sb.AppendLine($"Priority: {priority}");
            sb.AppendLine($"Size: {size}");
            sb.AppendLine($"Assignee: ---");
            sb.AppendLine("*************************");
            var sut = story.ToString();

            // Assert
            Assert.AreEqual(sb.ToString().Trim(), sut);
        }

        [TestMethod]
        public void ToStringPrintsCorrectMessageWithAssignee()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.Done;
            Priority priority = Priority.High;
            StorySize size = StorySize.Large;

            var firstName = "FirstName";
            var lastName = "LastName";
            var assignee = new Mock<IMember>();
            assignee.SetupGet(member => member.FirstName).Returns(firstName);
            assignee.SetupGet(member => member.LastName).Returns(lastName);

            // Act
            var story = new Story(title, description, status, priority, size, assignee.Object);

            var sb = new StringBuilder();
            sb.AppendLine($"Story Item");
            sb.AppendLine($"Title: {title}");
            sb.AppendLine($"Description: {description}");
            sb.AppendLine($"Item ID: {story.ID}");
            sb.AppendLine($"Comments: No comments yet");
            sb.AppendLine($"Status: {status}");
            sb.AppendLine($"Priority: {priority}");
            sb.AppendLine($"Size: {size}");
            sb.AppendLine($"Assignee: {assignee.Object.FirstName} {assignee.Object.LastName}");
            sb.AppendLine("*************************");
            var sut = story.ToString();

            // Assert
            Assert.AreEqual(sb.ToString().Trim(), sut);
        }
    }
}

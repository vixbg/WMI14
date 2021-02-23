using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WIM14.Models;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Tests.ModelsTests.StoryTests
{
    [TestClass]
    public class ToString_Should
    {
        [TestMethod]
        public void PrintProperInfo()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.NotDone;
            Priority priority = Priority.High;
            Size size = Size.Large;

            // Act
            var story = new Story(title, description, priority, size);

            var sb = new StringBuilder();
            sb.AppendLine($"{story.Type} ----");
            sb.AppendLine($"ID: {story.Id}");
            sb.AppendLine($"Status: {story.Status}");
            sb.AppendLine($"Priority: {story.Priority}");
            sb.AppendLine($"Size: {story.Size}");
            sb.AppendLine($"Title: {story.Title}");
            sb.AppendLine($"Description: {story.Description}");
            sb.AppendLine($"Assignee: {story.Assignee}");
            story.Comments.ForEach(c => sb.AppendLine($"Comments: {c}"));
            var sut = story.ToString();

            //Assert
            Assert.AreEqual(sb.ToString().Trim(), sut);
        }

        [TestMethod]
        public void PrintProperInfo_Assignee()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.NotDone;
            Priority priority = Priority.High;
            Size size = Size.Large;
            var assignee = new Member("StoryAuthor");

            // Act
            var story = new Story(title, description, priority, size);

            story.Assignee = assignee;
            var sb = new StringBuilder();
            sb.AppendLine($"{story.Type} ----");
            sb.AppendLine($"ID: {story.Id}");
            sb.AppendLine($"Status: {story.Status}");
            sb.AppendLine($"Priority: {story.Priority}");
            sb.AppendLine($"Size: {story.Size}");
            sb.AppendLine($"Title: {story.Title}");
            sb.AppendLine($"Description: {story.Description}");
            sb.AppendLine($"Assignee: {story.Assignee}");
            story.Comments.ForEach(c => sb.AppendLine($"Comments: {c}"));
            var sut = story.ToString();

            //Assert
            Assert.AreEqual(sb.ToString().Trim(), sut);
        }
        
    }
}

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
    public class UnasignMember_Should
    {
        [TestMethod]
        public void UnassignMemberCorrectly()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.Done;
            Priority priority = Priority.High;
            StorySize size = StorySize.Large;
            IMember assignee = new Mock<IMember>().Object;

            // Act
            var sut = new Story(title, description, status, priority, size, assignee);
            sut.Unassign();

            // Assert
            Assert.AreEqual(null, sut.Assignee);
        }

        [TestMethod]
        public void SetNullEvenWhenNoMember()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.Done;
            Priority priority = Priority.High;
            StorySize size = StorySize.Large;

            // Act
            var sut = new Story(title, description, status, priority, size);

            // Assert
            Assert.AreEqual(null, sut.Assignee);
        }

    }
}

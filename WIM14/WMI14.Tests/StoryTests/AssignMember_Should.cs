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
    public class AssignMember_Should
    {
        [TestMethod]
        public void AssignMemberCorrectly()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.Done;
            Priority priority = Priority.High;
            StorySize size = StorySize.Large;
            IMember assignee = new Mock<IMember>().Object;

            // Act
            var sut = new Story(title, description, status, priority, size);
            sut.AssignTo(assignee);

            // Assert
            Assert.AreEqual(assignee, sut.Assignee);
        }

        [TestMethod]
        public void ThrowsExceptionWhenDoubleAssigning()
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


            // Assert
            Assert.ThrowsException<ArgumentException>(() => sut.AssignTo(assignee));

        }

        

    }
}

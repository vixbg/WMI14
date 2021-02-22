using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;
using WMI14.Models.Contracts;
using WMI14.Models.Enums;

namespace WMI14.Tests.StoryTests
{
    [TestClass]
    public class ChangePriority_Should
    {
        [TestMethod]
        public void ChangePriorityCorrectly()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.Done;
            Priority priority = Priority.High;
            Priority newPriority = Priority.Low;
            StorySize size = StorySize.Large;

            // Act
            var sut = new Story(title, description, status, priority, size);
            sut.ChangePriority(newPriority);

            // Assert
            Assert.AreEqual(sut.Priority, newPriority);
        }
    }
}

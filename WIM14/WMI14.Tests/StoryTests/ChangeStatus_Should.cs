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
    public class ChangeStatus_Should
    {
        [TestMethod]
        public void ChangeStatusCorrectly()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.Done;
            StoryStatus newStatus = StoryStatus.InProgress;
            Priority priority = Priority.High;
            StorySize size = StorySize.Large;

            // Act
            var sut = new Story(title, description, status, priority, size);
            sut.ChangeStatus(newStatus);

            // Assert
            Assert.AreEqual(sut.Status, newStatus);
        }
    }
}

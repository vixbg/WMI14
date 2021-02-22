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
    public class ChangeSizeShould
    {
        [TestMethod]
        public void ChangeSizeCorrectly()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.Done;
            Priority priority = Priority.High;
            StorySize size = StorySize.Large;
            StorySize newSize = StorySize.Medium;

            // Act
            var sut = new Story(title, description, status, priority, size);
            sut.ChangeSize(newSize);

            // Assert
            Assert.AreEqual(sut.Size, newSize);
        }
    }
}

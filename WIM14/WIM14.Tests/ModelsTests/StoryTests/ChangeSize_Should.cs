﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Tests.ModelsTests.StoryTests
{
    [TestClass]
    public class ChangeSize_Should
    {
        [TestMethod]
        public void ChangeSizeSuccessfully()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.NotDone;
            Priority priority = Priority.High;
            Size size = Size.Large;

            // Act
            var sut = new Story(title, description, priority, size);
            sut.Size = size;

            // Assert
            Assert.AreEqual(sut.Size, size);
        }
    }
}
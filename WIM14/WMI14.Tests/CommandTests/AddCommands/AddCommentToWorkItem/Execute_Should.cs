using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.CommandTests.AddCommands.AddCommentToWorkItemCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ThrowIfParamsCountIsLessThanFour()
        {
            // Arrange
            var listInput = new List<string>() {"one", "two", "three" };
            var databaseMock = new Mock<Database>();
            
            // Act
            var sut = new AddCommentToWorkItemCommand(listInput, databaseMock.Object);

            // Assert
            Assert.ThrowsException<Exception>(() => sut.Execute());
            
        }

        [TestMethod]
        public void ThrowIfParamZeroIsNotIntParsable()
        {
            var listInput = new List<string>() { "one", "two", "three", "four" };
            var databaseMock = new Mock<Database>();

            var sut = new AddCommentToWorkItemCommand(listInput, databaseMock.Object);

            Assert.ThrowsException<Exception>(() => sut.Execute());
        }

        [TestMethod]
        public void ThrowIfIDOfItemDoesNotExistInDb()
        {
            var listInput = new List<string>() { "999", "randomNameOne", "randomNameTwo", "four" };
            var databaseMock = new Mock<Database>();

            var sut = new AddCommentToWorkItemCommand(listInput, databaseMock.Object);

            Assert.ThrowsException<Exception>(() => sut.Execute());
        }

        [TestMethod]
        public void ThrowIfNoSuchAuthorExistsInDb()
        {
            var databaseMock = new Mock<Database>() { CallBase = true };
            var fbMock = new Mock<Feedback>("randommmmmmfb1", "randomDescription", 3, FeedbackStatus.Done) { CallBase = true };
            databaseMock.Object.AddWorkItem(fbMock.Object);
            var listInput = new List<string>() { $"{fbMock.Object.ID}", "randomNameOne", "randomNameTwo", "four" };

            var sut = new AddCommentToWorkItemCommand(listInput, databaseMock.Object);

            Assert.ThrowsException<Exception>(() => sut.Execute());
        }

    }
}

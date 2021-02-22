using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.CommandTests.ListCommands
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ExecuteCorrectly_AllWorkItems()
        {
            // Arrange
            List<string> commandParams = new List<string>() { };
            var database = new Mock<IDatabase>() { CallBase = true }; 
            var bug = new Mock<IBug>();
            var story = new Mock<IStory>();
            database.SetupGet(item => item.WorkItems)
                .Returns(new Dictionary<int, IWorkItem>() { { 0, bug.Object }, { 1, story.Object } });
            var team = new Mock<ITeam>() { CallBase = true }; ;
            var board = new Mock<IBoard>();
            team.SetupGet(item => item.Name).Returns("teamName");
            string message = "";

            // Act
            var sut = new ListWorkItemsCommand(commandParams, database.Object);

            // Assert
            Assert.AreEqual(sut.Execute(), message);

        }

        [TestMethod]
        public void ExecuteCorrectly_TeamWorkItems()
        {
            // Arrange
            List<string> commandParams = new List<string>() {"teamName" };
            var database = new Mock<IDatabase>() { CallBase = true };
            var bug = new Mock<IBug>();
            bug.SetupGet(item => item.ID).Returns(1);
            var story = new Mock<IStory>();
            database.SetupGet(item => item.WorkItems)
                .Returns(new Dictionary<int, IWorkItem>() { { 1, bug.Object }, { 2, story.Object } });

            var board = new Mock<IBoard>();
            board.SetupGet(item => item.WorkItems).Returns(new Dictionary<int, IWorkItem>() { { 1, bug.Object }, { 2, story.Object } });
            var team = new Mock<ITeam>() { CallBase = true };
            team.SetupGet(item => item.Name).Returns("teamName");
            team.SetupGet(item => item.Boards).Returns(new Dictionary<int, IBoard>() { {1, board.Object}});
            database.SetupGet(item => item.Teams).Returns(new Dictionary<int, ITeam>() { { 1, team.Object } });
            string message = "";

            // Act
            var sut = new ListWorkItemsCommand(commandParams, database.Object);

            // Assert
            Assert.AreEqual(sut.Execute(), message);

        }
    }
}

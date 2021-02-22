using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.CommandTests.ShowCommands.ShowBoardActivity

{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ConstructorCorrectly()
        {
            var testList = new List<string>();
            var database = new Mock<IDatabase>().Object;

            var sut = new ShowBoardActivityCommand(testList, database);

            Assert.IsInstanceOfType(sut, typeof(ShowBoardActivityCommand));
        }



        [TestMethod]
        public void ExecuteCorrectly()
        {
            // Arrange
            string teamName = "teamone";
            string boardName = "boardone";

            IList<string> commandParams = new List<string>() { teamName, boardName };

            var database = new Mock<IDatabase>();
            var team = new Mock<ITeam>();
            var board = new Mock<IBoard>();

            var bug = new Mock<IBug>();
            bug.SetupGet(item => item.Title).Returns("bugOneAlaBala");
            bug.SetupGet(item => item.Description).Returns("leshtabrat");
            bug.SetupGet(item => item.Status).Returns(BugStatus.Active);


            // Act
            database.SetupGet(obj => obj.Members).Returns(new Dictionary<int, IMember>() { });
            database.SetupGet(obj => obj.Teams).Returns(new Dictionary<int, ITeam>() { { 0, team.Object } });
            database.SetupGet(obj => obj.WorkItems).Returns(new Dictionary<int, IWorkItem>() { { 1, bug.Object } });


            team.SetupGet(obj => obj.Name).Returns(teamName);
            team.SetupGet(obj => obj.Boards).Returns(new Dictionary<int, IBoard>() { { 0, board.Object } });
            team.SetupGet(obj => obj.Members).Returns(new Dictionary<int, IMember>() { });

            board.SetupGet(obj => obj.Name).Returns(boardName);
            board.SetupGet(obj => obj.WorkItems).Returns(new Dictionary<int, IWorkItem>() { { 1, bug.Object } });

            //board.Object.AddWorkItem(bug.Object);

            
            var result = new ShowBoardActivityCommand(commandParams, database.Object).Execute();
            var expected = board.Object.ViewActivityHistory();
            // Assert
            Assert.AreEqual(expected, result);

        }


        [TestMethod]
        [DataRow(new string[] { "nameone" })]
        [DataRow(new string[] { "nameone", "nametwo", "namethree" })]
        public void ExecuteThrowsException(string[] paramets)
        {
            List<string> commandParams = new List<string>();
            commandParams.AddRange(paramets);
            var database = new Mock<IDatabase>().Object;

            Assert.ThrowsException<Exception>(() => new ShowBoardActivityCommand(commandParams, database).Execute());
        }

    }

}
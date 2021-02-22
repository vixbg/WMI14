using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.CommandTests.ShowCommands.ShowTeamBoards
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ConstructorCorrectly()
        {
            var testList = new List<string>();
            var database = new Mock<IDatabase>().Object;

            var sut = new ShowTeamBoardsCommand(testList, database);

            Assert.IsInstanceOfType(sut, typeof(ShowTeamBoardsCommand));
        }


        [TestMethod]
        public void ExecuteCorrectly()
        {
            // Arrange
            var database = new Mock<IDatabase>().Object;

            IList<string> commandParams = new List<string>() { "teamOne" };

            var team = new Team("teamOne");

            database.AddTeam(team);

            var boardOne = new Board("first", team);
            var boardTwo = new Board("second", team);

            string expected;
            string result;

            // Act
            expected = team.ViewBoards();
            result = new ShowTeamBoardsCommand(commandParams, database).Execute();

            // Assert
            Assert.AreEqual(expected, result);

        }

        
        [TestMethod]
        [DataRow(new string[] { })]
        [DataRow(new string[] { "nameone" })]
        [DataRow(new string[] { "nameone", "nametwo", "namethree" })]
        public void ExecuteThrowsException(string[] paramets)
        {
            List<string> commandParams = new List<string>();
            var database = new Mock<IDatabase>().Object;
            commandParams.AddRange(paramets);

            Assert.ThrowsException<ArgumentException>(() => new ShowTeamBoardsCommand(commandParams, database).Execute());
        }





    }
}

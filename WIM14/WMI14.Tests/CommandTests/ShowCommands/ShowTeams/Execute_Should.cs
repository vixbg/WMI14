using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.CommandTests.ShowCommands.ShowTeams

{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ConstructorCorrectly()
        {
            var testList = new List<string>();
            var database = new Mock<IDatabase>().Object;

            var sut = new ShowTeamsCommand(testList, database);

            Assert.IsInstanceOfType(sut, typeof(ShowTeamsCommand));
        }


        [TestMethod]
        public void ExecuteCorrectly()
        {
            // Arrange
            var database = new Mock<IDatabase>().Object;

            IList<string> commandParams = new List<string>() {  };

            var teamone = new Team("teamOne");
            var teamTwo = new Team("teamTwo");
            var teamThree = new Team("teamThree");

            string expected;
            string result;

            // Act
            database.AddTeam(teamone);
            database.AddTeam(teamTwo);
            database.AddTeam(teamThree);

            // Assert
            expected = database.ViewTeams();
            result = new ShowTeamsCommand(commandParams, database).Execute();

        }


        [TestMethod]
        [DataRow(new string[] { "nameone" })]
        [DataRow(new string[] { "nameone", "nametwo", "namethree" })]
        public void ExecuteThrowsException(string[] paramets)
        {
            List<string> commandParams = new List<string>();
            var database = new Mock<IDatabase>().Object;
            commandParams.AddRange(paramets);

            Assert.ThrowsException<Exception>(() => new ShowTeamsCommand(commandParams, database).Execute());
        }





    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.CommandTests.ShowCommands.ShowTeamActivity
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ConstructorCorrectly()
        {
            var testList = new List<string>();
            var database = new Mock<IDatabase>().Object;

            var sut = new ShowTeamActivityCommand(testList, database);

            Assert.IsInstanceOfType(sut, typeof(ShowTeamActivityCommand));
        }

        [TestMethod]
        public void ExecuteCorrectly()
        {
            // Arrange
            var database = new Mock<IDatabase>().Object;

            IList<string> commandParams = new List<string>() { "teamOne" };

            IMember memberOne = new Member("leshto", "leshtov");
            IMember memberTwo = new Member("orizo", "orizov");

            var team = new Team("teamOne");

            string expected;
            string result;

            // Act

            database.AddTeam(team);

            team.AddMember(memberTwo);
            team.AddMember(memberOne);

            database.AddMember(memberTwo);
            database.AddMember(memberOne);

            expected = team.ViewActivity();
            result = new ShowTeamActivityCommand(commandParams, database).Execute();

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

            var sut = new ShowTeamActivityCommand(commandParams, database);

            Assert.ThrowsException<Exception>(() => sut.Execute());

        }


    }
}

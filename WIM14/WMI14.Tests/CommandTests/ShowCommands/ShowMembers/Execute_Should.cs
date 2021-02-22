using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.CommandTests.ShowCommands.ShowMembers
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ConstructorCorrectly()
        {
            var testList = new List<string>();
            var database = new Mock<IDatabase>().Object;

            var sut = new ShowMembersCommand(testList, database);

            Assert.IsInstanceOfType(sut, typeof(ShowMembersCommand));
        }

        [TestMethod]
        [DataRow("all")]
        [DataRow("teamOne")]
        public void ExecuteCorrectly(string paramet)
        {
            // Arrange
            var database = new Database();

            IList<string> commandParams = new List<string>() { paramet };

            IMember memberOne;
            IMember memberTwo;

            var team = new Team("teamOne");

            string expected;
            

            // Act

            switch (paramet)
            {
                case "all":
                    memberOne = new Member("leshto", "leshtov");
                    memberTwo = new Member("orizo", "orizov");

                    database.AddMember(memberTwo);
                    database.AddMember(memberOne);

                    expected = database.ViewMembers();

                    break;
                default:
                    memberOne = new Member("leshto", "leshtov");
                    memberTwo = new Member("orizo", "orizov");

                    database.AddTeam(team);

                    team.AddMember(memberTwo);
                    team.AddMember(memberOne);

                    expected = team.ViewMembers();

                    break;
            }

            var result = new ShowMembersCommand(commandParams, database).Execute();

            // Assert
            Assert.AreEqual(expected, result);




        }



        [TestMethod]
        [DataRow(new string[] {  })]
        [DataRow(new string[] { "teame"})]
        [DataRow(new string[] { "nameone", "nametwo" })]
        public void ExecuteThrowsException(string[] paramets)
        {
            List<string> commandParams = new List<string>();
            commandParams.AddRange(paramets);
            var database = new Mock<IDatabase>().Object;

            Assert.ThrowsException<Exception>(() => new ShowMembersCommand(commandParams, database).Execute());
        }



    }
}

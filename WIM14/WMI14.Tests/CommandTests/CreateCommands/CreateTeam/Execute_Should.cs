using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;
using System.Linq;

namespace WMI14.Tests.CommandTests.CreateCommands.CreateTeamCommandTests
{
    [TestClass]
    public class Execute_Should
    {

        [TestMethod]
        public void ThrowIfParamListCountNotOneElement()
        {
            var testList = new List<string>() { "320kila", "321kila" };
            var database = new Mock<IDatabase>().Object;

            var comm = new CreateTeamCommand(testList, database);

            Assert.ThrowsException<Exception>(() => comm.Execute());
        }

        [TestMethod]
        public void ThrowIfTeamAlreadyExistsInDb()
        {
            var testList = new List<string>() { "322kila" };
            var teamMock = new Mock<Team>("322kila");
            var database = new Mock<IDatabase>();
            database.SetupGet(obj => obj.Teams).Returns(new Dictionary<int, ITeam>() { { 0, teamMock.Object} });
            var comm = new CreateTeamCommand(testList, database.Object);

            Assert.ThrowsException<Exception>(() => comm.Execute());
        }

        [TestMethod]
        public void CreateAnInstanceOfATeam()
        {
            var testList = new List<string>() { "323kila" };
            var database = new Mock<IDatabase>();
            database.SetupGet(obj => obj.Teams).Returns(new Dictionary<int, ITeam>() {  });
            var comm = new CreateTeamCommand(testList, database.Object).Execute();


            Assert.AreEqual(comm, $"Team with name 323kila was created");
        }

        [TestMethod]
        [DataRow("jkhklhjk")]
        [DataRow("rewrwe")]
        [DataRow("asgdfghdfhsag")]
        [DataRow("asdhgfhfghsa")]
        [DataRow("asfghgfhgfdsa")]
        [DataRow("ashfhsfdfsddsa")]
        public void ReturnProperStringMessageUponCompletion(string whateverness)
        {
            var testList = new List<string>() { whateverness };
            var database = new Mock<IDatabase>();
            database.SetupGet(obj => obj.Teams).Returns(new Dictionary<int, ITeam>() { });
            var comm = new CreateTeamCommand(testList, database.Object).Execute();

            Assert.AreEqual(comm, $"Team with name {whateverness} was created");
        }




    }
}

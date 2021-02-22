using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.CommandTests.CreateCommands.CreateStoryTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiiiitle1", "dscriptiiiio1", "high", "medium"/*, "inprogress", "rndnamefrst", "rndnamescnd", "extraaa"*/})]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiiiiitle2", "dscriptiiiio2", "high", "medium"/*, "inprogress", "rndnamefrst", "rndnamescnd", "extraaa"*/})]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiiiiiitle3", "dscriptiiiio3", "high", "medium"/*, "inprogress", "rndnamefrst", "rndnamescnd", "extraaa"*/})]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiiiiiitle4", "dscriptiiiio4", "high", "medium", "inprogress", "rndnamefrst", "rndnamescnd", "extraaa" })]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiiitle5", "dscriptiiiio5", "high", "medium", "inprogress", "rndnamefrst", "rndnamescnd", "extraaa" })]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiiiitle6", "dscriptiiiio6", "high", "medium", "inprogress", "rndnamefrst", "rndnamescnd", "extraaa" })]
        public void ThrowIfNumberOfArgsIsOutOfReqs(string[] parametersArray)
        {
            var parameters = parametersArray.ToList();
            var database = new Mock<IDatabase>().Object;
            var sut = new CreateStoryCommand(parameters, database);

            Assert.ThrowsException<Exception>(() => sut.Execute());

        }



        [TestMethod]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiiitle1", "dscriptiiiio6", "highh", "medium", "inprogress", "rndnamefrst", "rndnamescnd", })]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiiitle1", "dscriptiiiio6", "higaa", "medium", "inprogress", "rndnamefrst", "rndnamescnd", })]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiitle1", "dscriptiiiio6", "higaa", "medium", "inprogress", "rndnamefrst", "rndnamescnd", })]
        public void ThrowIfPriorityIsInvalidEnum(string[] parametersArray)
        {
            var parameters = parametersArray.ToList();
            var teamRequired = new Team(parameters[0]);
            var database = new Mock<IDatabase>().Object;
            database.AddTeam(teamRequired);
            var boardReqired = new Board(parameters[1], teamRequired);
            teamRequired.AddBoard(boardReqired);

            var sut = new CreateStoryCommand(parameters, database);

            Assert.ThrowsException<Exception>(() => sut.Execute());

        }

        [TestMethod]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiitle1", "dscriptiiiio6", "high", "mediummm", "inprogress", "rndnamefrst", "rndnamescnd", })]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiitle1", "dscriptiiiio6", "high", "mediumd", "inprogress", "rndnamefrst", "rndnamescnd", })]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiitle1", "dscriptiiiio6", "high", "mediummds", "inprogress", "rndnamefrst", "rndnamescnd", })]
        public void ThrowIfSizeIsInvalidEnum(string[] parametersArray)
        {
            var parameters = parametersArray.ToList();
            var teamRequired = new Team(parameters[0]);
            var database = new Mock<IDatabase>().Object;
            database.AddTeam(teamRequired);
            var boardReqired = new Board(parameters[1], teamRequired);
            teamRequired.AddBoard(boardReqired);

            var sut = new CreateStoryCommand(parameters, database);

            Assert.ThrowsException<Exception>(() => sut.Execute());

        }

        [TestMethod]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiitle1", "dscriptiiiio6", "high", "medium", "inprogresss", "rndnamefrst", "rndnamescnd", })]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiitle1", "dscriptiiiio6", "high", "medium", "inprogressa", "rndnamefrst", "rndnamescnd", })]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiitle1", "dscriptiiiio6", "high", "medium", "inprogrenss", "rndnamefrst", "rndnamescnd", })]
        public void ThrowIfStatusIsInvalidEnum(string[] parametersArray)
        {
            var parameters = parametersArray.ToList();
            var teamRequired = new Team(parameters[0]);
            var database = new Mock<IDatabase>().Object;
            database.AddTeam(teamRequired);
            var boardReqired = new Board(parameters[1], teamRequired);
            teamRequired.AddBoard(boardReqired);

            var sut = new CreateStoryCommand(parameters, database);

            Assert.ThrowsException<Exception>(() => sut.Execute());

        }

        [TestMethod]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiitle1", "dscriptiiiio6", "high", "medium", "inprogress" })]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiitle2", "dscriptiiiio6", "high", "medium", "inprogress" })]
        [DataRow(new string[] { "teeam1", "booard1", "tiiiiiiitle2", "dscriptiiiio6", "high", "medium", "inprogress" })]
        public void ThrowIfItemIsAlreadyInTheBoard(string[] parametersArray)
        {
            var story = new Mock<IStory>();
            var database = new Mock<IDatabase>();
            database.SetupGet(obj => obj.WorkItems).Returns(new Dictionary<int, IWorkItem>() { { 0, story.Object } } );
            var comm = new CreateTeamCommand(parametersArray, database.Object);

            Assert.ThrowsException<Exception>(() => comm.Execute());
           
        }
    }
}

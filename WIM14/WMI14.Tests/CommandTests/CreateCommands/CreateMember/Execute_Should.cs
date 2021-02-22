using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.CommandTests.CreateCommands.CreateMemberCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        [DataRow("asdsa")]
        [DataRow("asdsa", "dsadas", "dsadsa")]
        [DataRow("asdsa", "dsadas", "dsadsa", "dsads")]
        [ExpectedException(typeof(Exception))]
        public void ThrowIfParamListArgumentsAreNotTwo(params string[] listcontents)
        {
            var testList = listcontents.ToList();
            var database = new Mock<IDatabase>().Object;

            var sut = new CreateMemberCommand(testList, database);

            sut.Execute();
        }

        [TestMethod]
        public void ThrowIfNameAlreadyExists()
        {
            // Arrange
            var firstName = "firstname";
            var lastName = "lastname";
            IList<string> commandParams = new List<string>() { firstName, lastName};
            var member = new Mock<IMember>();
            member.SetupGet(member => member.FirstName).Returns(firstName);
            member.SetupGet(member => member.LastName).Returns(lastName);
            var database = new Mock<IDatabase>();
            database.SetupGet(obj => obj.Members).Returns(new Dictionary<int, IMember>() { { 1, member.Object } });

            // Act
            var sut = new CreateMemberCommand(commandParams, database.Object);

            // Assert
            Assert.ThrowsException<Exception>(() => sut.Execute());
        }

        [TestMethod]
        [DataRow("Lemon", "Squeezy", 1)]
        [DataRow("Lenon", "Breezy", 2)]
        [DataRow("Lenor", "Squinzee", 3)]
        [DataRow("Lenovo", "McQuenzee", 4)]
        [DataRow("Lenard", "Frenzy", 5)]
        [DataRow("Leonardo", "DiCapreze", 6)]
        public void PrintCorrectInformation(string firstName, string lastName, int id)
        { 
            // Arrange
            IList<string> commandParams = new List<string>() { firstName, lastName };

            var member = new Mock<IMember>();
            member.SetupGet(member => member.FirstName).Returns(firstName);
            member.SetupGet(member => member.LastName).Returns(lastName);
            member.SetupGet(member => member.ID).Returns(id);

            var database = new Mock<IDatabase>();
            database.SetupGet(obj => obj.Members).Returns(new Dictionary<int, IMember>() { });


            // Act
            var sut = new CreateMemberCommand(commandParams, database.Object).Execute();

            // Assert
            Assert.AreEqual(sut, $"Member {member.Object.FirstName.First().ToString().ToUpper() + member.Object.FirstName[1..].ToLower()} " +
                $"and ID {member.Object.ID} created");
        }
        
       
    }
}

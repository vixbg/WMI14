using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Commands;
using WIM14.Core;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;

namespace WIM14.Tests.CommandsTests.MemberCommandsTests
{
    [TestClass]
    public class AddMemberCommand_Execute_Should
    {
        [TestMethod]
        [DataRow("test")]
        [DataRow("test", "test1", "test2")]
        public void Throw_When_ParamCountIsInvalid(params string[] parameters)
        {
            var database = new Mock<IDatabase>();
            var factory = new Mock<IFactory>();
            var sut = new AddMemberCommand(parameters, database.Object, factory.Object);

            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_ParamsDoNotExist()
        {
            //Arrange

            var database = new Mock<IDatabase>();
            database.SetupGet(x => x.Members).Returns(new List<IMember>());
            database.SetupGet(y => y.Teams).Returns(new List<ITeam>());
            var factory = new Mock<IFactory>();
            string[] parameters = { "Petkan", "Dragan" };
            var sut = new AddMemberCommand(parameters, database.Object, factory.Object);            

            //Act
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());

        }

    }
}

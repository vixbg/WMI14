using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands;
using WIM14.Core.Contracts;
using WIM14.Models;
using WIM14.Models.Contracts;

namespace WIM14.Tests.CommandsTests.MemberCommandsTests
{
    [TestClass]
    public class CreateMemberCommand_Execute_Should
    {
        [TestMethod]
        [DataRow("test", "test1")]
        [DataRow("test", "test1", "test2")]
        public void Throw_When_ParamCountIsInvalid(params string[] parameters)
        {
            var database = new Mock<IDatabase>();
            var factory = new Mock<IFactory>();
            var sut = new CreateMemberCommand(parameters, database.Object, factory.Object);            

            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_NameIsNotUnique()
        {
            //Arrange
            var database = new Mock<IDatabase>();
            var factory = new Mock<IFactory>();
            string name = "Rumyana";
            string[] args = new string[] { name };
            database.Setup(x => x.Members).Returns(new List<IMember>() { new Member(name)});

            var sut = new CreateMemberCommand(args, database.Object, factory.Object);

            //Act
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
            
        }

        [TestMethod]
        public void CreateMember_Correctly()
        {
            //Arrange 
            string[] name = { "Rumyana" };

            var database = new Mock<IDatabase>();
            var testList = new List<IMember>();
            database.SetupGet(x => x.Members).Returns(testList);

            var factory = new Mock<IFactory>();
            factory.Setup(x => x.CreateMember(It.IsAny<string>())).Returns(new Member(name[0]));

            var sut = new CreateMemberCommand(name, database.Object, factory.Object);

            //Act
            sut.Execute();

            //Assert
            Assert.IsTrue(testList.Any(x => x.Name == name[0]));

        }
    }
}

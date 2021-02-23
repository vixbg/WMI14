using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WIM14.Commands;

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
            var sut = new CreateMemberCommand(parameters);

            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_NameIsNotUnique()
        {
            //Arrange
            string[] name = { "Rumyana" };
            var command = new CreateMemberCommand(name);
            command.Execute();

            var sut = new CreateMemberCommand(name);

            //Act
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
            
        }

        [TestMethod]
        public void CreateMember_Correctly()
        {
            //Arrange 
            string[] name = { "Rumyana" };
            var sut = new CreateMemberCommand(name);
            string result = $"Member with ID 1 was created.";

            //Act
            //Assert
            Assert.AreEqual(result, sut.Execute());

        }
    }
}

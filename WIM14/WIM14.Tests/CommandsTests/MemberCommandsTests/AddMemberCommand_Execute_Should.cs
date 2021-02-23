using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WIM14.Commands;
using WIM14.Core;

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
            var sut = new AddMemberCommand(parameters);

            Assert.ThrowsException<ArgumentException>(() => sut.Execute());
        }

        [TestMethod]
        public void Throw_When_ParamsAreNull()
        {
            //Arrange
            string[] parameters = { null,null };
            var sut = new AddMemberCommand(parameters);
            

            //Act
            Assert.ThrowsException<ArgumentException>(() => sut.Execute());

        }

    }
}

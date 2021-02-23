using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models;
using WIM14.Models.Contracts;

namespace WIM14.Tests.ModelsTests.TeamTests
{
    [TestClass]
    public class AddMember_Should
    {
        [TestMethod]
        public void AddCorrectMember()
        {
            //Arrange
            var sut = new Team("Team14");
            var member = new Mock<IMember>().Object;

            //Act
            sut.AddPerson(member);

            //Assert
            Assert.IsTrue(sut.Members.Contains(member));
        }

        [TestMethod]
        public void Throw_When_MemberAlreadyExists()
        {
            //Arrange
            var sut = new Team("Team14");
            var member = new Mock<IMember>().Object;
            sut.AddPerson(member);

            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => sut.AddPerson(member));
        }
    }
}

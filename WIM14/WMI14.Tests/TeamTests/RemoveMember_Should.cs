using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;
using Moq;
using WMI14.Models.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WMI14.Tests.TeamTests
{
    [TestClass]
    public class RemoveMember_Should
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ThrowWhenNoSuchMemberExists()
        {
            var moqMember = new Mock<Member>("firstName", "lastName");
            new Team("RandomTeam").RemoveMember(moqMember.Object);
        }

        [TestMethod]
        public void RemoveProperlyIfMemberIsValid()
        {
            var moqMember = new Mock<Member>("firstName", "lastName");
            var teamProxy = new Mock<Team>("RandomTeam");
            teamProxy.Object.AddMember(moqMember.Object);

            Assert.IsTrue(teamProxy.Object.Members.Values.Contains(moqMember.Object));
            teamProxy.Object.RemoveMember(moqMember.Object);
            Assert.IsFalse(teamProxy.Object.Members.Values.Contains(moqMember.Object));
        }

    }
}

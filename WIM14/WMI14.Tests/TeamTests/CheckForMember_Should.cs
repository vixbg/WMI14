using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;
using Moq;
using WMI14.Models.Contracts;

namespace WMI14.Tests.TeamTests
{
    [TestClass]
    public class CheckForMember_Should
    {
        [TestMethod]
        public void ReturnFalseIfNoMemberIsFound()
        {
            Assert.AreEqual(false, new Team("teamName").ContainsMember(new Mock<IMember>().Object));
        }
    }
}

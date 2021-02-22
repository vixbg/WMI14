using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Models;

namespace WMI14.Tests.TeamTests
{
    [TestClass]
    public class GetWorkItemInfoByType_Should
    {
        [TestMethod]
        [DataRow("bugg")]
        [DataRow("storyy")]
        [DataRow("feedbacl")]
        [DataRow("null")]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenInvalidTypeIsPassed(string type)
        {
            //Arrange,Act,Assert:
            new Team("teamName").GetWorkItemInfoByType(type);

        }
    }
}

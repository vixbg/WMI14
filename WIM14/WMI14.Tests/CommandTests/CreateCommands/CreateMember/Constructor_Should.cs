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
    public class Constructor_Should
    {
        [TestMethod]
        public void ConstructIfProperParamTypeIsPassed()
        {
            var testList = new List<string>();
            var database = new Mock<IDatabase>().Object;

            var sut = new CreateMemberCommand(testList, database);

            Assert.IsInstanceOfType(sut, typeof(CreateMemberCommand));
        }

    }
}

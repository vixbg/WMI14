using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.CommandTests.CreateCommands.CreateTeamCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ConstructCorrectlyUsingValidInput()
        {
            var testList = new List<string>() { "320kila" };
            var database = new Mock<IDatabase>().Object;

            Assert.IsInstanceOfType(new CreateTeamCommand(testList, database), typeof(CreateTeamCommand));
        }



    }
}

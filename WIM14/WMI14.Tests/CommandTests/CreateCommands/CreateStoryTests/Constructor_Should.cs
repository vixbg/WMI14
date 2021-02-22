using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.CommandTests.CreateCommands.CreateStoryTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ConstructProperlyIfParamsAreOk()
        {
            var paramsList = new List<string>();
            var database = new Mock<IDatabase>().Object;
            Assert.IsInstanceOfType(new CreateStoryCommand(paramsList, database), typeof(CreateStoryCommand));

        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.CommandTests.AddCommands.AddCommentToWorkItemCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ConstructProperlyIfValidParamsArePassed()
        {
            var listPassed = new List<string>();
            var databasePassed = new Mock<Database>().Object;

            Assert.IsInstanceOfType(new AddCommentToWorkItemCommand(listPassed, databasePassed), typeof(AddCommentToWorkItemCommand));

        }
    }
}

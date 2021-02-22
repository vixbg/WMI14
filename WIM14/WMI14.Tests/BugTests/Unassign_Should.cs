using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.BugTests
{
    [TestClass]
    public class Unassign_Should
    {
        [TestMethod]
        public void UnassignSuccessfully()
        {
            // Arrange
            var expected = "Random bug";
            var description = "Description of bug";
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            var priority = Priority.High;
            var severity = BugSeverity.Critical;
            var status = BugStatus.Active;
            var assignee = new Mock<IMember>();
            assignee.SetupGet(item => item.FirstName).Returns("firstName");
            assignee.SetupGet(item => item.LastName).Returns("lastName");

            // Act
            var sut = new Bug(expected, description, steps, priority, severity, status, assignee.Object);
            sut.Unassign();

            // Assert
            Assert.AreEqual(sut.Assignee, null);
        }
    }
}

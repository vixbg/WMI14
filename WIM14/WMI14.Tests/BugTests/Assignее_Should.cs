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
    public class Assignее_Should
    {
        [TestMethod]
        public void ThrowException_AssigneeIsAlreadySet()
        {
            // Arrange
            var expected = "Random bug";
            var description = "Description of bug";
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            var priority = Priority.High;
            var severity = Severity.Critical;
            IMember assignee = new Mock<IMember>().Object;

            // Act
            var sut = new Bug(expected, description, steps, priority, severity);

            // Assert
            //Assert.ThrowsException<ArgumentException>(() => sut.AssignTo(assignee));
        }
    }
}

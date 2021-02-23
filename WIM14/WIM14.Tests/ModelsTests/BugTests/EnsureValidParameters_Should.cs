using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Tests.ModelsTests.BugTests
{
    [TestClass]
    public class EnsureValidParameters_Should
    {
        [TestMethod]
        public void ThrowExceptionIfTitleBelowRange()
        {
            // Arrange
            var expected = "Short";
            var description = "Description of bug";
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            var priority = Priority.High;
            var severity = BugSeverity.Critical;
            var status = BugStatus.Active;
            var firstName = "FirstName";
            var lastName = "Last Name";
            var assignee = new Mock<IMember>();
            assignee.SetupGet(member => member.FirstName).Returns(firstName);
            assignee.SetupGet(member => member.LastName).Returns(lastName);

            // Assert
            Assert.ThrowsException<Exception>(() => new Bug(expected, description, steps, priority, severity, status, assignee.Object));
        }
        [TestMethod]
        public void ThrowExceptionIfTitleAboveRange()
        {
            // Arrange
            var expected = new string('x', 51);
            var description = "Description of bug";
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            var priority = Priority.High;
            var severity = BugSeverity.Critical;
            var status = BugStatus.Active;
            var firstName = "FirstName";
            var lastName = "LastName";
            var assignee = new Mock<IMember>();
            assignee.SetupGet(member => member.FirstName).Returns(firstName);
            assignee.SetupGet(member => member.LastName).Returns(lastName);

            // Assert
            Assert.ThrowsException<Exception>(() => new Bug(expected, description, steps, priority, severity, status, assignee.Object));
        }
        [TestMethod]
        public void ThrowExceptionIfDescriptionBelowRange()
        {
            // Arrange
            var title = "Random bug";
            var expected = "Short";
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            var priority = Priority.High;
            var severity = BugSeverity.Critical;
            var status = BugStatus.Active;
            var firstName = "FirstName";
            var lastName = "LastName";
            var assignee = new Mock<IMember>();
            assignee.SetupGet(member => member.FirstName).Returns(firstName);
            assignee.SetupGet(member => member.LastName).Returns(lastName);

            // Assert
            Assert.ThrowsException<Exception>(() => new Bug(title, expected, steps, priority, severity, status, assignee.Object));
        }
        [TestMethod]
        public void ThrowExceptionIfDescriptionAboveRange()
        {
            // Arrange
            var title = "Random bug";
            var expected = new string('x', 501);
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            var priority = Priority.High;
            var severity = BugSeverity.Critical;
            var status = BugStatus.Active;
            var firstName = "FirstName";
            var lastName = "LastName";
            var assignee = new Mock<IMember>();
            assignee.SetupGet(member => member.FirstName).Returns(firstName);
            assignee.SetupGet(member => member.LastName).Returns(lastName);

            // Assert
            Assert.ThrowsException<Exception>(() => new Bug(title, expected, steps, priority, severity, status, assignee.Object));
        }
    }
}

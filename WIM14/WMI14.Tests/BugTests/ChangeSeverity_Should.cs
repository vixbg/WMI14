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
    public class ChangeSeverity_Should
    {
        [TestMethod]
        public void ChangeSeveritySuccessfully()
        {
            // Arrange
            var title = "Random bug";
            var description = "Description of bug";
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            var priority = Priority.High;
            var severity = BugSeverity.Critical;
            BugSeverity expected = BugSeverity.Major;
            var status = BugStatus.Active;
            IMember assignee = new Mock<IMember>().Object;

            // Act
            var sut = new Bug(title, description, steps, priority, severity, status, assignee);
            sut.ChangeSeverity(expected);

            // Assert
            Assert.AreEqual(sut.Severity, expected);
        }

    }
}

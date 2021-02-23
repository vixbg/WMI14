using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Tests.ModelsTests.BugTests
{
    [TestClass]
    public class ChangeStatus_Should
    {
        [TestMethod]
        public void ChangeStatusSuccessfully()
        {
            // Arrange
            var title = "Random bug";
            var description = "Description of bug";
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            var priority = Priority.High;
            var severity = BugSeverity.Critical;
            var status = BugStatus.Active;
            BugStatus expected = BugStatus.Fixed;
            IMember assignee = new Mock<IMember>().Object;

            // Act
            var sut = new Bug(title, description, steps, priority, severity, status, assignee);
            sut.ChangeStatus(expected);

            // Assert
            Assert.AreEqual(sut.Status, expected);
        }
    }
}

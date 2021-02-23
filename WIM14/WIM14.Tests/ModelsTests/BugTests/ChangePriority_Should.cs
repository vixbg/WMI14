using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Tests.ModelsTests.BugTests
{
    [TestClass]
    public class ChangePriority_Should
    {
        [TestMethod]
        public void ChangePrioritySuccessfully()
        {
            // Arrange
            var title = "Random bug";
            var description = "Description of bug";
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            Priority priority = Priority.High;
            Priority expected = Priority.Low;
            var severity = Severity.Critical;
            var status = BugStatus.Active;
            var assignee = new Mock<IMember>().Object;

            // Act
            var sut = new Bug(title, description, steps, priority, severity);
            //sut.ChangePriority(expected);

            // Assert
            Assert.AreEqual(sut.Priority, expected);
        }
    }
}

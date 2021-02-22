using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;
using System.Linq;

namespace WMI14.Tests.BugTests
{
    [TestClass]
    public class ToString_Should
    {
        [TestMethod]
        public void PrintProperInfo_NoAssignee()
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

            // Act
            var bug = new Bug(title, description, steps, priority, severity, status);
            var sb = new StringBuilder();
            sb.AppendLine($"Bug Item");
            sb.AppendLine($"Title: {title}");
            sb.AppendLine($"Description: {description}");
            sb.AppendLine($"Item ID: {bug.ID}");
            sb.AppendLine($"Comments: No comments yet");
            sb.AppendLine($"Steps: {String.Join(", ", steps)}");
            sb.AppendLine($"Priority: {priority}");
            sb.AppendLine($"Severity: {severity}");
            sb.AppendLine($"Status: {status}");
            sb.AppendLine($"Assignee: No assignee yet");
            sb.AppendLine("*************************");
            var sut = bug.ToString();

            //Assert
            Assert.AreEqual(sb.ToString().Trim(), sut);
        }
        [TestMethod]
        public void PrintProperInfo_Assignee()
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
            var firstName = "FirstName";
            var lastName = "LastName";
            var assignee = new Mock<IMember>();
            assignee.SetupGet(member => member.FirstName).Returns(firstName);
            assignee.SetupGet(member => member.LastName).Returns(lastName);

            // Act
            var bug = new Bug(title, description, steps, priority, severity, status, assignee.Object);
            var sb = new StringBuilder();
            sb.AppendLine($"Bug Item");
            sb.AppendLine($"Title: {title}");
            sb.AppendLine($"Description: {description}");
            sb.AppendLine($"Item ID: {bug.ID}");
            sb.AppendLine($"Comments: No comments yet");
            sb.AppendLine($"Steps: {String.Join(", ", steps)}");
            sb.AppendLine($"Priority: {priority}");
            sb.AppendLine($"Severity: {severity}");
            sb.AppendLine($"Status: {status}");
            sb.AppendLine($"Assignee: {assignee.Object.FirstName.First().ToString().ToUpper() + assignee.Object.FirstName[1..].ToLower()} " +
                $"{assignee.Object.LastName.First().ToString().ToUpper() + assignee.Object.LastName[1..].ToLower()}");
            sb.AppendLine("*************************");
            var sut = bug.ToString();

            //Assert
            Assert.AreEqual(sb.ToString().Trim(), sut);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WIM14.Models;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Tests.ModelsTests.BugTests
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
            var severity = Severity.Critical;
            var status = BugStatus.Active;

            // Act
            var bug = new Bug(title, description, steps, priority, severity);
            var sb = new StringBuilder();
            sb.AppendLine($"{bug.WorkItemType} ----");
            sb.AppendLine($"ID: {bug.Id}");
            sb.AppendLine($"Status: {status}");
            sb.AppendLine($"Priority: {priority}");
            sb.AppendLine($"Severity: {severity}");
            sb.AppendLine($"Title: {title}");
            sb.AppendLine($"Description: {description}");
            sb.AppendLine($"Assignee: {bug.Assignee}");
            sb.AppendLine($"Steps to Reproduce:");
            bug.StepsToReproduce.ForEach(s => sb.AppendLine($"|{s}|"));
            bug.Comments.ForEach(c => sb.AppendLine($"Comments: {c}"));
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
            var severity = Severity.Critical;
            var status = BugStatus.Active;
            var firstName = "FirstName";
            var lastName = "LastName";
            var assignee = new Member("AssigneeName");


            // Act
            var bug = new Bug(title, description, steps, priority, severity);
            bug.Assignee = assignee;
            var sb = new StringBuilder();
            sb.AppendLine($"{bug.WorkItemType} ----");
            sb.AppendLine($"ID: {bug.Id}");
            sb.AppendLine($"Status: {status}");
            sb.AppendLine($"Priority: {priority}");
            sb.AppendLine($"Severity: {severity}");
            sb.AppendLine($"Title: {title}");
            sb.AppendLine($"Description: {description}");
            sb.AppendLine($"Assignee: {bug.Assignee}");
            sb.AppendLine($"Steps to Reproduce:");
            bug.StepsToReproduce.ForEach(s => sb.AppendLine($"|{s}|"));
            bug.Comments.ForEach(c => sb.AppendLine($"Comments: {c}"));
            var sut = bug.ToString();

            //Assert
            Assert.AreEqual(sb.ToString().Trim(), sut);
        }
    }
}

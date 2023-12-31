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
    public class Constructor_Should
    {

        [TestMethod]
        public void AssignCorrectTitle()
        {
            // Arrange
            var expected = "Random bug";
            var description = "Description of bug";
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            var priority = Priority.High;
            var severity = Severity.Critical;

            // Act
            var sut = new Bug(expected, description, steps, priority, severity);

            // Assert
            Assert.AreEqual(expected, sut.Title);
        }

        [TestMethod]
        public void AssignCorrectDescription()
        {
            // Arrange
            var title = "Random bug";
            var expected = "Description of bug";
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            var priority = Priority.High;
            var severity = Severity.Critical;

            // Act
            var sut = new Bug(title, expected, steps, priority, severity);

            // Assert
            Assert.AreEqual(expected, sut.Description);
        }

        [TestMethod]
        public void AssignCorrectStepsToReproduce()
        {
            // Arrange
            var title = "Random bug";
            var description = "Description of bug";
            List<string> expected = new List<string>();
            expected.Add("Step 1 to reproduce bug");
            expected.Add("Step 2 to reproduce bug");
            var priority = Priority.High;
            var severity = Severity.Critical;

            // Act
            var sut = new Bug(title, description, expected, priority, severity);

            // Assert
            Assert.AreEqual(expected, sut.StepsToReproduce);
        }

        [TestMethod]
        public void AssignCorrectPriority()
        {
            // Arrange
            var title = "Random bug";
            var description = "Description of bug";
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            var expected = Priority.High;
            var severity = Severity.Critical;

            // Act
            var sut = new Bug(title, description, steps, expected, severity);

            // Assert
            Assert.AreEqual(expected, sut.Priority);
        }

        [TestMethod]
        public void AssignCorrectSeverity()
        {
            // Arrange
            var title = "Random bug";
            var description = "Description of bug";
            List<string> steps = new List<string>();
            steps.Add("Step 1 to reproduce bug");
            steps.Add("Step 2 to reproduce bug");
            var priority = Priority.High;
            var expected = Severity.Critical;

            // Act
            var sut = new Bug(title, description, steps, priority, expected);

            // Assert
            Assert.AreEqual(expected, sut.Severity);
        }

    }
}

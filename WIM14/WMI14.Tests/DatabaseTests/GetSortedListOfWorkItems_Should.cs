using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMI14.Core;
using WMI14.Core.Contracts;
using WMI14.Models;
using WMI14.Models.Contracts;
using WMI14.Models.Enums;

namespace WMI14.Tests.DatabaseTests
{
    [TestClass]
    public class GetSortedListOfWorkItems_Should
    {
        [TestMethod]
        [DataRow("title", "asc")]
        [DataRow("title", "desc")]
        [DataRow("priority", "asc")]
        [DataRow("priority", "desc")]
        [DataRow("severity", "asc")]
        [DataRow("severity", "desc")]
        [DataRow("size", "asc")]
        [DataRow("size", "desc")]
        [DataRow("rating", "asc")]
        [DataRow("rating", "desc")]
        public void SortedWIWorksCorrectly(string type, string order)
        {
            // Arrange
            var combination = (type, order);
            IWorkItem one;
            IWorkItem two;

            var database = new Database();
            List<IWorkItem> list = new List<IWorkItem>();
            List<IWorkItem>sorted = new List<IWorkItem>();

            // Act
            switch (combination)
            {
                case ("title", "asc"):
                    sorted.Clear();

                    one = new Bug("randombug1", "descriptionofbug", new List<string>() { "step1", "step2", "step3" }, Priority.High, BugSeverity.Critical, BugStatus.Active);
                    two = new Bug("randombug2", "descriptionofbug", new List<string>() { "step1", "step2", "step3" }, Priority.Low, BugSeverity.Major, BugStatus.Fixed);

                    database.AddWorkItem(one);
                    database.AddWorkItem(two);

                    list.Add(one);
                    list.Add(two);
                    sorted.Add(one);
                    sorted.Add(two);

                    break;
                case ("title", "desc"):
                    sorted.Clear();

                    one = new Bug("randombug1", "descriptionofbug", new List<string>() { "step1", "step2", "step3" }, Priority.High, BugSeverity.Critical, BugStatus.Active);
                    two = new Bug("randombug2", "descriptionofbug", new List<string>() { "step1", "step2", "step3" }, Priority.Low, BugSeverity.Major, BugStatus.Fixed);

                    database.AddWorkItem(one);
                    database.AddWorkItem(two);

                    list.Add(one);
                    list.Add(two);
                    sorted.Add(two);
                    sorted.Add(one);

                    break;

                case ("priority", "asc"):
                    sorted.Clear();

                    one = new Bug("randombug1", "descriptionofbug", new List<string>() { "step1", "step2", "step3" }, Priority.High, BugSeverity.Critical, BugStatus.Active);
                    two = new Bug("randombug2", "descriptionofbug", new List<string>() { "step1", "step2", "step3" }, Priority.Low, BugSeverity.Major, BugStatus.Fixed);

                    database.AddWorkItem(one);
                    database.AddWorkItem(two);

                    list.Add(one);
                    list.Add(two);
                    sorted.Add(one);
                    sorted.Add(two);

                    break;

                case ("priority", "desc"):
                    sorted.Clear();

                    one = new Bug("randombug1", "descriptionofbug", new List<string>() { "step1", "step2", "step3" }, Priority.High, BugSeverity.Critical, BugStatus.Active);
                    two = new Bug("randombug2", "descriptionofbug", new List<string>() { "step1", "step2", "step3" }, Priority.Low, BugSeverity.Major, BugStatus.Fixed);

                    database.AddWorkItem(one);
                    database.AddWorkItem(two);

                    list.Add(one);
                    list.Add(two);
                    sorted.Add(two);
                    sorted.Add(one);

                    break;

                case ("severity", "asc"):
                    sorted.Clear();

                    one = new Bug("randombug1", "descriptionofbug", new List<string>() { "step1", "step2", "step3" }, Priority.High, BugSeverity.Critical, BugStatus.Active);
                    two = new Bug("randombug2", "descriptionofbug", new List<string>() { "step1", "step2", "step3" }, Priority.Low, BugSeverity.Major, BugStatus.Fixed);

                    database.AddWorkItem(one);
                    database.AddWorkItem(two);

                    list.Add(one);
                    list.Add(two);
                    sorted.Add(one);
                    sorted.Add(two);

                    break;

                case ("severity", "desc"):
                    sorted.Clear();

                    one = new Bug("randombug1", "descriptionofbug", new List<string>() { "step1", "step2", "step3" }, Priority.High, BugSeverity.Critical, BugStatus.Active);
                    two = new Bug("randombug2", "descriptionofbug", new List<string>() { "step1", "step2", "step3" }, Priority.Low, BugSeverity.Major, BugStatus.Fixed);

                    database.AddWorkItem(one);
                    database.AddWorkItem(two);

                    list.Add(one);
                    list.Add(two);
                    sorted.Add(two);
                    sorted.Add(one);

                    break;

                case ("size", "asc"):
                    sorted.Clear();

                    one = new Story("randomstory1", "descriptionofstory", StoryStatus.InProgress, Priority.Low, StorySize.Large);
                    two = new Story("randomstory2", "descriptionofstory", StoryStatus.NotDone, Priority.High, StorySize.Medium);

                    database.AddWorkItem(one);
                    database.AddWorkItem(two);

                    list.Add(one);
                    list.Add(two);
                    sorted.Add(one);
                    sorted.Add(two);

                    break;

                case ("size", "desc"):
                    sorted.Clear();

                    one = new Story("randomstory1", "descriptionofstory", StoryStatus.InProgress, Priority.Low, StorySize.Large);
                    two = new Story("randomstory2", "descriptionofstory", StoryStatus.NotDone, Priority.High, StorySize.Medium);

                    database.AddWorkItem(one);
                    database.AddWorkItem(two);

                    list.Add(one);
                    list.Add(two);
                    sorted.Add(two);
                    sorted.Add(one);

                    break;

                case ("rating", "asc"):
                    sorted.Clear();

                    one = new Feedback("randomfeedback1", "descriptionoffeedback", 1, FeedbackStatus.Done);
                    two = new Feedback("randomfeedback2", "descriptionoffeedback", 5, FeedbackStatus.New);

                    database.AddWorkItem(one);
                    database.AddWorkItem(two);

                    list.Add(one);
                    list.Add(two);
                    sorted.Add(one);
                    sorted.Add(two);

                    break;

                case ("rating", "desc"):
                    sorted.Clear();

                    one = new Feedback("randomfeedback1", "descriptionoffeedback", 1, FeedbackStatus.Done);
                    two = new Feedback("randomfeedback2", "descriptionoffeedback", 5, FeedbackStatus.New);

                    database.AddWorkItem(one);
                    database.AddWorkItem(two);

                    list.Add(one);
                    list.Add(two);
                    sorted.Add(two);
                    sorted.Add(one);

                    break;

                default:
                    break;
            }

            var DBItems = database.GetSortedListOfWorkItems(list, type, order);

            bool outcome = DBItems.SequenceEqual(sorted);

            // Assert
            Assert.AreEqual(true, outcome);

        }

        [TestMethod]
        [DataRow("leshta","asc")]
        [DataRow("size","leshta")]
        [DataRow("leshta","leshta")]
        public void GetSortedThrowsException(string type, string order)
        {
            // Arrange
            var database = new Mock<IDatabase>().Object;
            IWorkItem one;
            IWorkItem two;
            List<IWorkItem> list = new List<IWorkItem>();

            one = new Bug("randombug1", "descriptionofbug", new List<string>() { "step1", "step2", "step3" }, Priority.High, BugSeverity.Critical, BugStatus.Active);
            two = new Bug("randombug2", "descriptionofbug", new List<string>() { "step1", "step2", "step3" }, Priority.Low, BugSeverity.Major, BugStatus.Fixed);

            database.AddWorkItem(one);
            database.AddWorkItem(two);

            list.Add(one);
            list.Add(two);
            var sut = database.GetSortedListOfWorkItems(list, type, order);

            // Act & Assert
            Assert.ThrowsException<Exception>(() => sut);

        }




    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WMI14.Core;
using WMI14.Models;
using WMI14.Models.Contracts;
using WMI14.Models.Enums;

namespace WMI14.Tests.DatabaseTests
{
    [TestClass]
    public class GetGlobalWorkItemsByType_Should
    {
        [TestMethod]
        [DataRow("bug")]
        [DataRow("story")]
        [DataRow("feedback")]
        public void GetItemsCorrectly(string type)
        {
            // Arrange
            var database = new Database();

            var test = database.WorkItems.Count;

            List<IWorkItem> items;

            // Act
            switch (type)
            {
                case "bug":
                    var bugOne = new Bug("bugOneAlaBala", "leshtabrat", BugStatus.Active);
                    var bugTwo = new Bug("bugTwoAlaBala", "leshtabrat", BugStatus.Fixed);
                    var bugThree = new Bug("bugThreeAlaBala", "leshtabrat", BugStatus.Fixed);

                    database.AddWorkItem(bugOne);
                    database.AddWorkItem(bugTwo);
                    database.AddWorkItem(bugThree);

                    items = new List<IWorkItem>() { bugOne, bugTwo, bugThree };
                    break;
                case "story":
                    var storyOne = new Story("storyOneAlaBala", "leshtabrat", StoryStatus.Done);
                    var storyTwo = new Story("storyTwoAlaBala", "leshtabrat", StoryStatus.InProgress);
                    var storyThree = new Story("storyThreeAlaBala", "leshtabrat", StoryStatus.NotDone);

                    database.AddWorkItem(storyOne);
                    database.AddWorkItem(storyTwo);
                    database.AddWorkItem(storyThree);

                    items = new List<IWorkItem>() { storyOne, storyTwo, storyThree };
                    break;
                case "feedback":
                    var feedbackOne = new Feedback("feedbackOneAlaBala", "leshtabrat", FeedbackStatus.Unscheduled);
                    var feedbackTwo = new Feedback("feedbackTwoAlaBala", "leshtabrat", FeedbackStatus.Unscheduled);
                    var feedbackThree = new Feedback("feedbackThreeAlaBala", "leshtabrat", FeedbackStatus.Unscheduled);

                    database.AddWorkItem(feedbackOne);
                    database.AddWorkItem(feedbackTwo);
                    database.AddWorkItem(feedbackThree);

                    items = new List<IWorkItem>() { feedbackOne, feedbackTwo, feedbackThree };
                    break;
                default:
                    items = new List<IWorkItem>();
                    break;
            }

            var DBItems = database.GetWorkItemsByType(type);

            // Assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(items[i].ID, DBItems[i].ID);
            }


        }

        private class Feedback : WorkItem, IFeedback
        {
            public Feedback(string title, string description, FeedbackStatus status)
                : base(title, description, status.ToString())
            {
                workItemID++;
            }

            public int Rating => throw new NotImplementedException();

            public FeedbackStatus Status => throw new NotImplementedException();

            string IWorkItem.Status => throw new NotImplementedException();

            public void ChangeRating(int newRating)
            {
                throw new NotImplementedException();
            }

            public void ChangeStatus(FeedbackStatus status)
            {
                throw new NotImplementedException();
            }
        }

        private class Story : WorkItem, IStory
        {
            public Story(string title, string description, StoryStatus status)
                : base(title, description, status.ToString())
            {
                workItemID++;
            }

            public Priority Priority => throw new NotImplementedException();

            public StorySize Size => throw new NotImplementedException();

            public IMember Assignee => throw new NotImplementedException();

            string IWorkItem.Status => throw new NotImplementedException();

            StoryStatus IStory.Status => throw new NotImplementedException();

            public void AssignTo(IMember assignee)
            {
                throw new NotImplementedException();
            }

            public void ChangePriority(Priority priority)
            {
                throw new NotImplementedException();
            }

            public void ChangeSize(StorySize newSize)
            {
                throw new NotImplementedException();
            }

            public void ChangeStatus(StoryStatus status)
            {
                throw new NotImplementedException();
            }

            public void Unassign()
            {
                throw new NotImplementedException();
            }

        }

        private class Bug : WorkItem, IBug
        {
            public Bug(string title, string description, BugStatus status) : base(title, description, status.ToString())
            {
                workItemID++;
            }
            public IList<string> Steps => throw new NotImplementedException();

            public Priority Priority => throw new NotImplementedException();

            public BugSeverity Severity => throw new NotImplementedException();

            public BugStatus Status => throw new NotImplementedException();

            public IMember Assignee => throw new NotImplementedException();

            string IWorkItem.Status => throw new NotImplementedException();

            public void AssignTo(IMember assignee)
            {
                throw new NotImplementedException();
            }

            public void ChangePriority(Priority priority)
            {
                throw new NotImplementedException();
            }

            public void ChangeSeverity(BugSeverity severity)
            {
                throw new NotImplementedException();
            }

            public void ChangeStatus(BugStatus status)
            {
                throw new NotImplementedException();
            }

            public void Unassign()
            {
                throw new NotImplementedException();
            }
        }

    }
}

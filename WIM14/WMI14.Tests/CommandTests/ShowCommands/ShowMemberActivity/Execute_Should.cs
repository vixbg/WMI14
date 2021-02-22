using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.CommandTests.ShowCommands.ShowMemberActivity

{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ConstructorCorrectly()
        {
            var testList = new List<string>();
            var database = new Mock<IDatabase>().Object;

            var sut = new ShowMemberActivityCommand(testList, database);

            Assert.IsInstanceOfType(sut, typeof(ShowMemberActivityCommand));
        }

        [TestMethod]
        public void ExecuteCorrectly()
        {
            // Arrange
            var database = new Mock<IDatabase>().Object;

            string firstName = "Zhelyazko";
            string lastName = "Blagoev";

            IList<string> commandParams = new List<string>() { firstName, lastName };

            var member = new Member(firstName, lastName);

            var bugOne = new Bug("bugOneAlaBala", "leshtabrat", BugStatus.Active);
            var bugTwo = new Bug("bugTwoAlaBala", "leshtabrat", BugStatus.Fixed);
            var bugThree = new Bug("bugThreeAlaBala", "leshtabrat", BugStatus.Fixed);

            // Act
            database.AddMember(member);

            member.AssignWorkItem(bugOne);
            member.AssignWorkItem(bugTwo);
            member.AssignWorkItem(bugThree);

            var expected = member.ViewActivityHistory();
            var result = new ShowMemberActivityCommand(commandParams, database).Execute();

            // Assert
            Assert.AreEqual(expected, result);

        }


        [TestMethod]
        [DataRow(new string[] { "nameone" })]
        [DataRow(new string[] { "nameone", "nametwo", "namethree" })]
        public void ExecuteThrowsException(string[] paramets)
        {
            List<string> commandParams = new List<string>();
            commandParams.AddRange(paramets);
            var database = new Mock<IDatabase>().Object;

            Assert.ThrowsException<Exception>(() => new ShowMemberActivityCommand(commandParams, database).Execute());

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

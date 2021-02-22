using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;
using System.Linq;

namespace WMI14.Tests.BoardTests
{
    [TestClass]
    public class RemoveWorkItem_Should
    {
        [TestMethod]
        public void ThrowException_ItemDoesNotExistInBoard()
        {
            // Arrange
            var item = new FakeWorkItem();
            var board = new FakeBoard();

            // Assert & Act
            Assert.ThrowsException<InvalidOperationException>(() => board.RemoveWorkItem(item));
        }


        private class FakeBoard : IBoard
        {
            private readonly Dictionary<int, IWorkItem> workItems = new Dictionary<int, IWorkItem>();
            public int ID => throw new NotImplementedException();

            public string Name { get; }

            public IReadOnlyDictionary<int, IWorkItem> WorkItems => throw new NotImplementedException();

            public void AddWorkItem(IWorkItem item)
            {
                throw new NotImplementedException();
            }

            public bool ContainsWorkItem(IWorkItem item)
            {
                return this.workItems.ContainsKey(item.ID);
            }

            public void RemoveWorkItem(IWorkItem item)
            {
                bool contains = ContainsWorkItem(item);

                if (contains)
                {
                    this.workItems.Remove(item.ID);
                }
                else
                {
                    throw new InvalidOperationException($"{item.GetType().Name} '{item.Title}' not in board '{this.Name}'");
                }
            }

            public string ViewActivityHistory()
            {
                throw new NotImplementedException();
            }

            public string ViewWorkItems()
            {
                throw new NotImplementedException();
            }
        }

        private class FakeWorkItem : IWorkItem
        {
            public int ID { get; }

            public string Title { get; }

            public string Description => throw new NotImplementedException();

            public string Status => throw new NotImplementedException();

            public void AddComment(IMember author, string comment)
            {
                throw new NotImplementedException();
            }

            public string ViewActivityHistory()
            {
                throw new NotImplementedException();
            }
        }
    }
}

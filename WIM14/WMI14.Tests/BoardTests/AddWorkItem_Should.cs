using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WMI14.Tests.BoardTests
{
    [TestClass]
    public class AddWorkItem_Should
    {
        [TestMethod]
        public void ThrowException_ItemDuplicate()
        {
            // Arrange
            var item = new FakeWorkItem();
            var board = new FakeBoard();

            // Act
            board.AddWorkItem(item);

            // Assert
            Assert.ThrowsException<InvalidOperationException>(() => board.AddWorkItem(item));            
        }

        private class FakeBoard : IBoard
        {
            private readonly Dictionary<int, IWorkItem> workItems = new Dictionary<int, IWorkItem>();
            public int ID => throw new NotImplementedException();

            public string Name { get; }

            public IReadOnlyDictionary<int, IWorkItem> WorkItems => throw new NotImplementedException();

            public void AddWorkItem(IWorkItem item)
            {
                bool contains = ContainsWorkItem(item);
                if (contains)
                {
                    throw new InvalidOperationException($"{item.GetType().Name} {item.Title} is already in board '{this.Name}'");
                }

                this.workItems.Add(item.ID, item);
            }

            public bool ContainsWorkItem(IWorkItem item)
            {
                return this.workItems.ContainsKey(item.ID);
            }

            public void RemoveWorkItem(IWorkItem item)
            {
                throw new NotImplementedException();
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

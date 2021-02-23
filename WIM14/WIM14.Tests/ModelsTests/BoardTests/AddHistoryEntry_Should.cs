using Microsoft.VisualStudio.TestTools.UnitTesting;
using WIM14.Models;

namespace WIM14.Tests.ModelsTests.BoardTests
{
    [TestClass]
    public class AddHistoryEntry_Should
    {
        [TestMethod]
        public void AddCorrectMessage()
        {
            //Arrange
            var sut = new Board("WIM14Board"); //here we add one
            string message = "Testing.";

            //Act
            sut.AddHistoryEntry(message); //adding the second

            //Assert
            Assert.AreEqual(message, sut.ActivityHistory[1].Description);
        }
    }
}

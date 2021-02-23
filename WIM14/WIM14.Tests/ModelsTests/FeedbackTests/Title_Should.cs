using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WIM14.Core.Contracts;
using WIM14.Models;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Tests.ModelsTests.FeedbackTests
{
    [TestClass]
    public class Title_Should
    {
        [TestMethod]
        public void SetCorrectValue()
        {
            // Arrange
            var title = "Random feedback";
            var description = "Description of feedback";
            var rating = 3;
            var newTitle = "ValidTitle";

            // Act
            var sut = new Feedback(title, description, rating);
            sut.Title = newTitle;

            //Assert
            Assert.AreEqual(newTitle, sut.Title);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("name")]
        [DataRow("arbitrium arbitror architecto arcu ardore arguerent ars")]
        public void ThrowException(string newTitle)
        {
            // Arrange
            var title = "Random feedback";
            var description = "Description of feedback";
            var rating = 3;
            
            // Act
            var sut = new Feedback(title, description, rating);

            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Title = newTitle);
        }
    }
}


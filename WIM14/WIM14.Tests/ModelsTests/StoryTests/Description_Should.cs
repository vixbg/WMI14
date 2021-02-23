using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Tests.ModelsTests.StoryTests
{ [TestClass]
    public class Description_Should
    {
        [TestMethod]
        public void SetCorrectValue()
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.NotDone;
            Priority priority = Priority.High;
            Size size = Size.Large;
            var newDescription = "ValidDescription";

            // Act
            var sut = new Story(title, description, priority, size);
            sut.Description = newDescription;
            
            //Assert
            Assert.AreEqual(newDescription, sut.Description);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("name")]
        [DataRow("careret caret caritatem carum causa causae causam causas cedentem celeritas censes censet centurionum cepisse ceramico cernantur cernimus certa certae certamen certe certissimam ceteris cetero ceterorum ceteros choro chorusque chremes chrysippe chrysippi chrysippo cibo cillum circumcisaque cives civibus civitas civitatis civium clamat clariora claris clarorum class claudicare clita coercendi coerceri cogitarent cogitavisse cogitemus cognita cognitio cognitione cognitionem cognitionis cognitioque cognomen cognoscerem cognosci cohaerescant comiti")]
        public void ThrowException(string newDescription)
        {
            // Arrange
            string title = "best_story";
            string description = new string('a', 15);
            StoryStatus status = StoryStatus.NotDone;
            Priority priority = Priority.High;
            Size size = Size.Large;

            // Act
            var sut = new Story(title, description, priority, size);

            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Description = newDescription);
        }
    }
}

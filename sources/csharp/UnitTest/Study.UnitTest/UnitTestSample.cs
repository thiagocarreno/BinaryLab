using FluentAssertions;
using Moq;
using NUnit.Framework;
using Study.UnitTest.Implements;
using Study.UnitTest.Interfaces;
using Study.UnitTest.Models;
using System.Collections.Generic;

namespace Study.UnitTest
{
    [TestFixture]

    public class UnitTestSample
    {
        [Test]
        public void ShouldReturnSampleObject()
        {
            //Setup
            var mockObject = new SampleObject
            {
                Id = 1
            };

            var repository = new Mock<IRepository>();
            repository.Setup(i => i.GetById(It.IsAny<int>())).Returns(mockObject);

            //Act
            var business = new Business(repository.Object);
            var model = business.GetById(mockObject.Id);

            //Assert
            model.Should().Be(mockObject, "Not are equals.");

            //Verify
            repository.Verify(i => i.GetById(mockObject.Id), Times.Once(), "ShouldReturnSampleObject failed.");

        }

        [Test]
        public void ShouldReturnSampleObjectCollection()
        {
            //Setup
            var sampleObject = new SampleObject
            {
                Id = 1
            };

            var mockObject = new List<SampleObject> { sampleObject };

            var repository = new Mock<IRepository>();
            repository.Setup(i => i.Select(It.IsAny<SampleObject>())).Returns(mockObject);

            //Act
            var business = new Business(repository.Object);
            var model = business.Select(sampleObject);

            //Assert
            model.Should().BeEquivalentTo(mockObject, "Not are equals.");

            //Verify
            repository.Verify(i => i.Select(sampleObject), Times.Once(), "ShouldReturnSampleObjectCollection failed.");

        }
    }
}
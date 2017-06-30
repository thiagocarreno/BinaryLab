using Moq;
using NUnit.Framework;
using Study.UnitTest.Implements;
using Study.UnitTest.Interfaces;
using Study.UnitTest.Models;

namespace Study.UnitTest
{
    [TestFixture]
    public class UnitTestSample
    {
        [Test]
        public void TestSample()
        {
            //Setup
            var mockObject = new SampleObject
            {
                Id = 1
            };

            var respository = new Mock<IRepository>();
            respository.Setup(i => i.GetById(It.IsAny<int>())).Returns(mockObject);

            //Act
            var business = new Business(respository.Object);
            var model = business.GetById(mockObject.Id);

            //Assert
            Assert.AreEqual(model, mockObject);
        }
    }
}
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace GraveKiller
{
    public class GameControllerLocatorTests
    {
        [TearDown]
        public void TearDown()
        {
            GameControllerLocator.GetInstance().Clear();
        }
        
        [Test]
        public void WhenTryToGetARegistredController_ShouldReturnTheController()
        {
            var sut = GameControllerLocator.GetInstance();
            var doc = Substitute.For<TestController>();
            sut.RegisterController(doc);

            var result = sut.GetController<TestController>();
            
            Assert.That(result.Equals(doc));
        }
        
        [Test]
        public void WhenTryToGetAControllerWithoutRegistring_ShouldReturnException()
        {
            var sut = GameControllerLocator.GetInstance();

            Assert.Throws<KeyNotFoundException>(() =>
            {
                sut.GetController<TestController>();
            });
        }
 
        
        [Test]
        public void WhenTryToUnregisterARegistredControllerAndThenGetController_ShouldReturnException()
        {
            //Arrange
            var sut = GameControllerLocator.GetInstance();
            var doc = Substitute.For<TestController>();
            
            //Act
            sut.RegisterController<TestController>(doc);
            sut.GetController<TestController>();
            sut.UnRegisterController<TestController>();
            
            //Assert
            Assert.Throws<KeyNotFoundException>(() =>
            {
                sut.GetController<TestController>();
            });
        }
    }

    public interface TestController
    {
    }
}

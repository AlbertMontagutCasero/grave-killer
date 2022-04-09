using System.Numerics;
using NUnit.Framework;

namespace GraveKiller
{
    public class SharedTypesExtensionsTests
    {
        [Test]
        public void EngineVector2ToSystemVector2()
        {
            UnityEngine.Vector2 engineVector = new UnityEngine.Vector2(1,2);
            Vector2 systemVector = new Vector2(1,2);

            Assert.That(engineVector.ToSystemVector2().Equals(systemVector));
        }
        
        [Test]
        public void Vector2ToEngineVector2()
        {
            Vector2 systemVector = new Vector2(3,4);
            UnityEngine.Vector2 engineVector = new UnityEngine.Vector2(3,4);

            Assert.That(systemVector.ToUnityVector2().Equals(engineVector));
        }

        [Test]
        public void Vector3ToVector2()
        {
            var sut = new Vector3(2, 3, 4);
            var expectedResult = new Vector2(2, 3);
            
            Assert.That(sut.ToSystemVector2().Equals(expectedResult));
        }
        
        [Test]
        public void Vector2ToVector3()
        {
            var sut = new Vector2(2, 3);
            var expectedResult = new Vector3(2, 3, 0);

            Assert.That(sut.ToSystemVector3().Equals(expectedResult));
        }
        
        [Test]
        public void EngineVector3ToVector3()
        {
            var sut = new UnityEngine.Vector3(2, 3, 4);
            var expectedResult = new Vector3(2, 3, 4);

            Assert.That(sut.ToSystemVector3().Equals(expectedResult));
        }
        
        [Test]
        public void Vector3ToEngineVector3()
        {
            var sut = new Vector3(2, 3, 4);
            var expectedResult = new UnityEngine.Vector3(2, 3, 4);

            Assert.That(sut.ToUnityVector3().Equals(expectedResult));
        }
        
        [Test]
        public void EngineVector3ToVector2()
        {
            var sut = new UnityEngine.Vector3(2, 3, 4);
            var expectedResult = new Vector2(2, 3);

            Assert.That(sut.ToSystemVector2().Equals(expectedResult));
        } 
        
        [Test]
        public void Vector2ToEngineVector3()
        {
            var sut = new Vector2(2, 3);
            var expectedResult = new UnityEngine.Vector3(2, 3, 0);

            Assert.That(sut.ToUnityVector3().Equals(expectedResult));
        }
        
        [Test]
        public void Vector3ToEngineVector2()
        {
            var sut = new Vector3(2, 3, 4);
            var expectedResult = new UnityEngine.Vector2(2, 3);

            Assert.That(sut.ToUnityVector2().Equals(expectedResult));
        }
    }
}

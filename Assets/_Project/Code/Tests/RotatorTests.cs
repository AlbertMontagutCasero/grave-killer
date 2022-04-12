using NUnit.Framework;
using UnityEngine;

namespace GraveKiller
{
    public class RotatorTests
    {
        [TestCase(1, 0, 90)]
        [TestCase(0, -1, 180)]
        [TestCase(-1, 0, 270)]
        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 0)]
        public void GetRotationToWithOriginAndTarget_ThenRotationShouldBeOriginToTarget(float targetX, float targetZ, float expectedAngle)
        {
            var origin = Vector3.zero;
            var target = new Vector3(targetX, 0, targetZ);

            var sut = new Rotator();
            var result = sut.GetRotationTo(origin, target);

            var expectedResult = Vector3.up * expectedAngle; 
            
            Assert.That(result.eulerAngles.Equals(expectedResult));
        }   
    }
}

using NUnit.Framework;
using UnityEngine;

namespace GraveKiller
{
    public class CharacterMovementTest
    {
        [Test]
        public void GetNextPositionDeltaWithDirectionAndSpeed_ShouldBeInThisPositionAfterATime()
        {

            var direction = Vector3.forward;

            var sut = new CharacterMovement(direction, 1, 5);

            var result = sut.GetNextPositionDelta();
            var expectedResult = Vector3.forward * 5;
            
            Assert.That(result.Equals(expectedResult));
        }
        
        [Test]
        public void GetNextPositionDeltaWithNODirectionAndSpeed_ShouldBeInTheSamePlace()
        {
            var direction = Vector3.zero;

            var sut = new CharacterMovement(direction, 1, 5);

            var result = sut.GetNextPositionDelta();
            var expectedResult = Vector3.zero;
            
            Assert.That(result.Equals(expectedResult));
        }
    }
}

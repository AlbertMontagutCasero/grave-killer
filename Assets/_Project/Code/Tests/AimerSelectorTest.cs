using NUnit.Framework;
using UnityEngine;

namespace GraveKiller
{
    public class AimerSelectorTest
    {
        [Test]
        public void GetNextRotationWithNoEnemyAndMovingToRight_ThenShouldBeRightRotation()
        {
            var movementRequest = new MovementRequest();
            movementRequest.SetHorizontal(1);

            var sut = new AimerSelector();
            sut.SetUp(movementRequest);

            var result = sut.GetNextRotation();
            var expectedResult = new Vector3(0, 90, 0);

            Assert.That(result.eulerAngles.Equals(expectedResult));
        }
        
        [Test]
        public void GetNextRotationWithNoEnemyAndAfterMoving_ThenShouldBeTheLastRotation()
        {
            var toRightMovementRequest = new MovementRequest();
            var sut = new AimerSelector();

            toRightMovementRequest.SetHorizontal(1);
            sut.SetUp(toRightMovementRequest);

            var noMovementRequest = new MovementRequest();
            sut.SetUp(noMovementRequest);

            var result = sut.GetNextRotation();
            var expectedResult = new Vector3(0, 90, 0);

            Assert.That(result.eulerAngles.Equals(expectedResult));
        }
    }
}


// Player finds enemies inside its range 
// Player aims close enemy
// Player player finds enemies near of him
// If Player has no enemy in its range and it is not moving, then follows the last direction rotation


// If Player has no enemy in its range, then follows the moving rotation

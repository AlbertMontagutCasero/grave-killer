using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace GraveKiller
{
    public class AimerSelectorTest
    {
        [Test]
        public void
            GetNextRotationWithNoEnemyAndMovingToRight_ThenShouldBeRightRotation()
        {
            var sut = this.GetAimSelector();

            var movementRequest = new MovementRequest();
            movementRequest.SetHorizontal(1);
            sut.SetUp(movementRequest);

            var result = sut.GetNextRotation();
            var expectedResult = new Vector3(0, 90, 0);

            Assert.That(result.eulerAngles.Equals(expectedResult));
        }

        [Test]
        public void
            GetNextRotationWithNoEnemyAndAfterMoving_ThenShouldBeTheLastRotation()
        {
            var sut = this.GetAimSelector();

            var toRightMovementRequest = new MovementRequest();
            toRightMovementRequest.SetHorizontal(1);
            sut.SetUp(toRightMovementRequest);
            sut.GetNextRotation();

            var noMovementRequest = new MovementRequest();
            sut.SetUp(noMovementRequest);

            var result = sut.GetNextRotation();
            var expectedResult = new Vector3(0, 90, 0);

            Assert.That(result.eulerAngles.Equals(expectedResult));
        }

        [Test]
        public void GetNextRotationWithEnemyInRange_ThenShouldRotateToTheEnemy()
        {
            var enemyListPositions = new[] {
                new Vector3(1, 0, 0), new Vector3(1, 0, 1)
            };

            var sut =
                this.GetAimSelectorWithPhysicsEnemyPositions(enemyListPositions,
                    Vector3.zero);

            sut.GetNextRotation();

            var result = sut.GetNextRotation();
            var expectedResult = new Vector3(0, 90, 0);

            Assert.That(result.eulerAngles.Equals(expectedResult));
        }

        private AimerSelector GetAimSelector()
        {
            var docPhysics = Substitute.For<PhysicsRaycast>();
            var docPlayerPosition = Substitute.For<PlayerPositionProvider>();
            var docPlayerStats = Substitute.For<PlayerStats>();

            return new AimerSelector(docPhysics,
                docPlayerPosition,
                docPlayerStats);
        }

        private AimerSelector GetAimSelectorWithPhysicsEnemyPositions(
            Vector3[] enemyListPositions,
            Vector3 playerPosition)
        {
            var docPhysics = Substitute.For<PhysicsRaycast>();

            docPhysics
                .GetPositionsOverlappingSphere(Arg.Any<Vector3>(),
                    Arg.Any<float>(),
                    Arg.Any<int>())
                .Returns(enemyListPositions);

            var docPlayerPosition = Substitute.For<PlayerPositionProvider>();
            docPlayerPosition.GetPosition().Returns(playerPosition);

            var docPlayerStats = Substitute.For<PlayerStats>();

            return new AimerSelector(docPhysics,
                docPlayerPosition,
                docPlayerStats);
        }
    }
}

// Player finds enemies inside its range 
// Player aims close enemy
// Player player finds enemies near of him
// If Player has no enemy in its range and it is not moving, then follows the last direction rotation

// If Player has no enemy in its range, then follows the moving rotation

using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace GraveKiller
{
    public class PlayerTests
    {
        [Test]
        public void GetNextPosition()
        {
            var speed = 10;
            var delta = 10;
            var horizontalDirection = 1;
            var forwardDirection = 0;
            var startPosition = new Vector3(2, 0, 3);
            var doc = Substitute.For<PlayerMotor>();
            doc.GetPosition().Returns(startPosition);

            var sut = new Player(doc, new PlayerStats(speed));
            var movementRequest = new MovementRequest();
            movementRequest.SetHorizontal(horizontalDirection);
            movementRequest.SetForward(forwardDirection);

            var result = sut.GetNextPosition(movementRequest, delta);

            var expectedResult =
                new Vector3(startPosition.x + speed * delta * horizontalDirection,
                    0,
                    startPosition.z + speed * delta * forwardDirection);

            Assert.That(result.Equals(expectedResult));
        }
    }
}

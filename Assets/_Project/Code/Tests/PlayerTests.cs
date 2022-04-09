using System.Numerics;
using NSubstitute;
using NUnit.Framework;

namespace GraveKiller
{
    public class PlayerTests
    {

        [Test]
        public void GetNextPosition()
        {
            var speed = 10;
            var delta = 10;
            var xDirection = 1;
            var yDirection = 0;
            var startPosition = new Vector2(2,3);
            var doc = Substitute.For<PlayerMotor>();
            doc.GetPosition().Returns(startPosition);
            
            var sut = new Player(doc, new PlayerStats(speed));
            var movementRequest = new MovementRequest();
            movementRequest.direction.X = xDirection;
            movementRequest.direction.Y = yDirection;

            var result = sut.GetNextPosition(movementRequest, delta);

            var expectedResult =
                new Vector2(startPosition.X + speed * delta * xDirection,
                    startPosition.Y + speed * delta * yDirection);
            
            Assert.That(result.Equals(expectedResult));
        }
    }
}

using NUnit.Framework;
using UnityEngine;

namespace GraveKiller
{
    public class MovementRequestTests
    {
        [TestCase( 0,0,0,0,0,0)]
        [TestCase( 1, 0, 0, 0,-1, 0)]
        [TestCase( 0, 1, 0, 0,1, 0)]
        [TestCase( 0, 0, 0, 1,0, -1)]
        public void InputDirectionTest(int left, int right, int top, int down, int expectedDirectionX, int expectedDirectionY)
        {
            var movementRequest = new MovementRequest();
            movementRequest.direction.x -= left;
            movementRequest.direction.x += right;

            movementRequest.direction.y += top;
            movementRequest.direction.y -= down;

            var expectedDirection =
                new Vector2(expectedDirectionX, expectedDirectionY);
            Assert.That(movementRequest.direction.Equals(expectedDirection));
        }

        [Test]
        public void NoMovement()
        {
            var sut = new MovementRequest();

            Assert.That(!sut.HasDirection());
        }
        
        [Test]
        public void HasMovement()
        {
            var sut = new MovementRequest();
            sut.direction.y = 1;
            
            Assert.That(sut.HasDirection());
        }
    }
}

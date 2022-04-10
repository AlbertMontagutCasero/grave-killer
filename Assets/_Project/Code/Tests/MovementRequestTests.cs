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
        public void InputDirectionTest(int left, int right, int top, int down, int expectedDirectionX, int expectedDirectionForward)
        {
            var movementRequest = new MovementRequest();
            movementRequest.SetHorizontal(-left);
            movementRequest.SetHorizontal(right);

            movementRequest.SetForward(top);
            movementRequest.SetForward(-down);

            var expectedDirection =
                new Vector3(expectedDirectionX, 0, expectedDirectionForward);
            var result = movementRequest.GetVector3Direction();
            Assert.That(result.Equals(expectedDirection));
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
            sut.SetForward(1);
            
            Assert.That(sut.HasDirection());
        }
    }
}

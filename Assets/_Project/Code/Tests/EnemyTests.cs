using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace GraveKiller
{
    public class EnemyTests
    {
        [Test]
        public void EnemyMovement()
        {
            var playerPosition = new Vector3(0, 0,0);
            var playerPositionProviderDoc = Substitute.For<PlayerPositionProvider>();
            playerPositionProviderDoc.GetPosition().Returns(playerPosition);
            
            var enemyMotorDoc = Substitute.For<EnemyMotor>();
            enemyMotorDoc.GetPosition().Returns(new Vector3(-6, 0, 0));
            var sut = new Enemy(playerPositionProviderDoc, enemyMotorDoc);

            var deltaSecondsElapsed = 1f;
            var result = sut.GetNextMovement(deltaSecondsElapsed);

            var expectedResult = new Vector3(-1, 0, 0);
            Assert.That(result.Equals(expectedResult));
        }
    }
}

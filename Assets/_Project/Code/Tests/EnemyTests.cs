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
            var playerPosition = new Vector2(1, 2);
            var playerPositionProviderDoc = Substitute.For<PlayerPositionProvider>();
            playerPositionProviderDoc.GetPosition().Returns(playerPosition);
            
            var enemyMotorDoc = Substitute.For<EnemyMotor>();
            enemyMotorDoc.GetPosition().Returns(new Vector2(-1, 2));
            var sut = new Enemy(playerPositionProviderDoc, enemyMotorDoc);

            var deltaSecondsElapsed = 2f;
            var result = sut.GetNextMovement(deltaSecondsElapsed);

            float speed = 1;
            var direction = new Vector2(1, 0);
            var expectedResult = playerPosition + direction * (speed * deltaSecondsElapsed);

            Assert.That(result.Equals(expectedResult));
        }
    }
}

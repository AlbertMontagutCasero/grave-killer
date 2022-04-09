using System.Collections.Generic;
using System.Numerics;
using NSubstitute;
using NUnit.Framework;

namespace GraveKiller
{
    public class EnemyGeneratorTests
    {
        [TestCase(1f, 5f, 5)]
        [TestCase(2f, 3.99999f, 1)]
        [TestCase(3f, 6.000001f, 2)]
        public void SpawnEnemyEveryXSeconds(
            float spawnEverySeconds,
            float elapsedSeconds,
            int recivedTimes)
        {
            var doc = Substitute.For<EnemyGeneratorMotor>();
            var sut = new EnemyGenerator(spawnEverySeconds, doc, null);

            var deltaSecondsElapsed = elapsedSeconds;
            sut.AddTime(deltaSecondsElapsed);

            doc.Received(recivedTimes).GenerateNewEnemy();
        }

        [Test]
        public void GetSpawnPoint()
        {
            var doc = Substitute.For<EnemyGeneratorMotor>();
            var spawnPoints = new List<Vector2> {
                new Vector2(5, 0),
                new Vector2(5, 10),
                new Vector2(0, 10),
                new Vector2(-5, 10),
                new Vector2(-5, 10)
            };
            var sut = new EnemyGenerator(default, doc, spawnPoints);

            
            var spawnPointsAmount = spawnPoints.Count;
            for (int i = 0; i < spawnPointsAmount * 4; i++)
            {
                var result = sut.GetSpawnPoint();
                
                var expectedSpawnPoint = spawnPoints[i % spawnPointsAmount];
                Assert.That(result.Equals(expectedSpawnPoint));
            }
        }
    }
}

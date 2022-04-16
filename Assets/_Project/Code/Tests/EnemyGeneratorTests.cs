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
            var sut = new EnemyGenerator(spawnEverySeconds, doc);

            var deltaSecondsElapsed = elapsedSeconds;
            sut.AddTime(deltaSecondsElapsed);

            doc.Received(recivedTimes).GenerateNewEnemy();
        }

        [Test]
        public void GetSpawnPoint()
        {
            Assert.Fail();
        }
    }
}

using NSubstitute;
using NUnit.Framework;
using UnityEngine;

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
            var mapStartCoordinates = 0;
            var squaredMapSize = 20;
            var docPlayerPosition = new Vector3(5, 0, 0);
            var docMapSize = new Vector3(squaredMapSize, 0, squaredMapSize);

            var docSquaredSpawnZone = new SquaredSpawnZone(
                new SignedRange(new Range(5, 10)),
                new SignedRange(new Range(10, 12)));

            var sut = new EnemyGenerator(Mathf.Infinity, null);
            var spawnPoint = sut.GetSpawnPoint();

            var spawnPointXPositionIsInsideMap = spawnPoint.x >= mapStartCoordinates &&
                                                 spawnPoint.x <= squaredMapSize;

            var spawnPointYPositionIsInsideMap = spawnPoint.z >= mapStartCoordinates &&
                                                 spawnPoint.z <= squaredMapSize;

            Assert.That(spawnPointXPositionIsInsideMap);
            Assert.That(spawnPointYPositionIsInsideMap);

            var correctRangeMinPositiveX = docPlayerPosition.x + 5;
            var correctRangeMaxPositiveX = docPlayerPosition.x + 10;
            var correctRangeMinNegativeX = -correctRangeMaxPositiveX;
            var correctRangeMaxNegativeX = -correctRangeMinPositiveX;

            var correctRangeMinPositiveY = docPlayerPosition.z + 10;
            var correctRangeMaxPositiveY = docPlayerPosition.z + 12;
            var correctRangeMinNegativeY = -correctRangeMaxPositiveY;
            var correctRangeMaxNegativeY = -correctRangeMinPositiveY;

            var isXInTheCorrectRange =
                (spawnPoint.x >= correctRangeMinPositiveX &&
                 spawnPoint.x <= correctRangeMaxPositiveX) ||
                (spawnPoint.x >= correctRangeMinNegativeX &&
                 spawnPoint.x <= correctRangeMaxNegativeX);

            var isYInTheCorrectRange =
                (spawnPoint.z >= correctRangeMinPositiveY &&
                 spawnPoint.z <= correctRangeMaxPositiveY) ||
                (spawnPoint.z >= correctRangeMinNegativeY &&
                 spawnPoint.z <= correctRangeMaxNegativeY);

            Assert.That(isXInTheCorrectRange,
                $"x = {spawnPoint.x}, expected >={correctRangeMinPositiveX} <= {correctRangeMaxPositiveX} >= {correctRangeMinNegativeX} <= {correctRangeMaxNegativeX}");

            Assert.That(isYInTheCorrectRange,
                $"y = {spawnPoint.z}, expected >={correctRangeMinPositiveY} <= {correctRangeMaxPositiveY} >= {correctRangeMinNegativeY} <= {correctRangeMaxNegativeY}");
        }
    }
}

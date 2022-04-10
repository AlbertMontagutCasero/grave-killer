using System.Collections.Generic;
using System.Numerics;

namespace GraveKiller
{
    public class EnemyGenerator
    {
        private float elapsedTime;
        private float spawnEverySeconds;
        private EnemyGeneratorMotor enemyGeneratorMotor;
        private int currentSpawnPoint;
        private List<Vector2> spawnPoints;

        public EnemyGenerator(
            float spawnEverySeconds,
            EnemyGeneratorMotor enemyGeneratorMotor,
            List<Vector2> spawnPoints)
        {
            this.spawnEverySeconds = spawnEverySeconds;
            this.enemyGeneratorMotor = enemyGeneratorMotor;
            this.spawnPoints = spawnPoints;
        }

        public void AddTime(float deltaSecondsElapsed)
        {
            this.elapsedTime += deltaSecondsElapsed;

            while (this.elapsedTime >= this.spawnEverySeconds)
            {
                this.elapsedTime -= this.spawnEverySeconds;
                this.enemyGeneratorMotor.GenerateNewEnemy();
            }
        }

        public Vector2 GetSpawnPoint()
        {
            var current = this.spawnPoints[this.currentSpawnPoint];

            this.currentSpawnPoint =
                (this.currentSpawnPoint + 1) % this.spawnPoints.Count;

            return current;
        }
    }
}

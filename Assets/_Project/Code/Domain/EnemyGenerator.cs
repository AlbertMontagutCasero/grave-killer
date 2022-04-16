using System;
using System.Collections.Generic;
using UnityEngine;

namespace GraveKiller
{
    public class EnemyGenerator
    {
        private float elapsedTime;
        private float spawnEverySeconds;
        private EnemyGeneratorMotor enemyGeneratorMotor;

        public EnemyGenerator(
            float spawnEverySeconds,
            EnemyGeneratorMotor enemyGeneratorMotor)
        {
            this.spawnEverySeconds = spawnEverySeconds;
            this.enemyGeneratorMotor = enemyGeneratorMotor;

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

        public Vector3 GetSpawnPoint()
        {
            // var current = this.spawnPoints[this.currentSpawnPoint];
            //
            // this.currentSpawnPoint =
            //     (this.currentSpawnPoint + 1) % this.spawnPoints.Count;

            throw new Exception("NOT IMPLEMENTED");
        }
    }
}

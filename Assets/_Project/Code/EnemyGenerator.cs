using System;
using System.Collections.Generic;
using System.Numerics;

namespace GraveKiller
{
    public class EnemyGenerator
    {
        private readonly EnemyGeneratorMotor enemyGeneratorMotor;
        private int enemeyCount;
        private Random random;

        public EnemyGenerator(EnemyGeneratorMotor enemyGeneratorMotor)
        {
            this.enemyGeneratorMotor = enemyGeneratorMotor;
            this.random = new Random();
        }

        public void SpawnEnemiesTest()
        {
            int enemyNumber = 500;

            for (int i = 0; i < enemyNumber; i++)
            {
                var randomX = (float)(random.NextDouble());
                var randomY = (float)(random.NextDouble());
                var randomZ = (float)(random.NextDouble());

                var position = new Vector3(randomX, randomY, randomZ);
                position *= 15;
                this.enemyGeneratorMotor.GenerateNewEnemy(position);
                this.enemeyCount++;
            }
        }

        public int GetEnemyCount()
        {
            return this.enemeyCount;
        }

        public IEnumerable<Vector3> GetEnemyPositions()
        {
            return this.enemyGeneratorMotor.GetEnemyPositions();
        }
    }
}

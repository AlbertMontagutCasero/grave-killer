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
        private readonly SquaredSpawnZone spawnZone;
        private readonly MapSize mapSize;
        private readonly PlayerPositionProvider playerPositionProvider;

        public EnemyGenerator(
            float spawnEverySeconds,
            EnemyGeneratorMotor enemyGeneratorMotor)
        {
            this.spawnEverySeconds = spawnEverySeconds;
            this.enemyGeneratorMotor = enemyGeneratorMotor;
        }

        public EnemyGenerator(
            float spawnEverySeconds,
            EnemyGeneratorMotor enemyGeneratorMotor,
            SquaredSpawnZone spawnZone,
            MapSize mapSize,
            PlayerPositionProvider playerPositionProvider)
        {
            this.spawnEverySeconds = spawnEverySeconds;
            this.enemyGeneratorMotor = enemyGeneratorMotor;
            this.spawnZone = spawnZone;
            this.mapSize = mapSize;
            this.playerPositionProvider = playerPositionProvider;
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
            var playerPosition = this.playerPositionProvider.GetPosition();

            float spawnX;
            float spawnY;
            bool isInsideLeft;
            bool isInsideRight;
            bool isInsideTop;
            bool isInsideBottom;

            do
            {
                spawnX = playerPosition.x + this.spawnZone.GetX();
                spawnY = playerPosition.z + this.spawnZone.GetY();
                
                isInsideLeft = spawnX >= this.mapSize.startX;
                isInsideRight = spawnX <= this.mapSize.startX + this.mapSize.width;
                isInsideBottom = spawnY >= this.mapSize.startY;
                isInsideTop = spawnY <= this.mapSize.startY + this.mapSize.height;
            } while (!isInsideLeft || !isInsideRight || !isInsideBottom || !isInsideTop);

            return new Vector3(spawnX, 0, spawnY);
        }
    }
}

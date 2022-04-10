using UnityEngine;
namespace GraveKiller
{
    public class Enemy
    {
        private PlayerPositionProvider playerPositionProvider;
        private EnemyMotor enemyMotor;
        private readonly int speed;

        public Enemy(PlayerPositionProvider playerPositionProvider, EnemyMotor enemyMotor)
        {
            this.playerPositionProvider = playerPositionProvider;
            this.enemyMotor = enemyMotor;
            this.speed = 5;
        }
        public Vector2 GetNextMovement(float deltaSecondsElapsed)
        {
            var playerPosition = this.playerPositionProvider.GetPosition();
            var enemyCurrentPosition = this.enemyMotor.GetPosition();

            Vector2 currentPosition = (playerPosition - enemyCurrentPosition);

            return currentPosition;
        }

    }
}

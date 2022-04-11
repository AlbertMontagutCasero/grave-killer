using UnityEngine;

namespace GraveKiller
{
    public class Enemy
    {
        private readonly PlayerPositionProvider playerPositionProvider;
        private readonly EnemyMotor enemyMotor;
        private readonly int speed;

        public Enemy(
            PlayerPositionProvider playerPositionProvider,
            EnemyMotor enemyMotor)
        {
            this.playerPositionProvider = playerPositionProvider;
            this.enemyMotor = enemyMotor;
            this.speed = 5;
        }

        public Vector3 GetNextMovement(float deltaSecondsElapsed)
        {
            var playerPosition = this.playerPositionProvider.GetPosition();
            var enemyCurrentPosition = this.enemyMotor.GetPosition();

            var direction = (playerPosition - enemyCurrentPosition);
            direction.y = 0;
            direction *= 0.5f;

            var nextPositionDelta = new CharacterMovement(direction,
                deltaSecondsElapsed,
                this.speed).GetNextPositionDelta();

            return nextPositionDelta;
        }
    }
}

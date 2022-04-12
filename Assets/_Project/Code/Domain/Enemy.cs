using UnityEngine;

namespace GraveKiller
{
    public class Enemy
    {
        private readonly PlayerPositionProvider playerPositionProvider;
        private readonly EnemyMotor enemyMotor;
        private readonly int speed;
        private readonly CharacterMovement characterMovement;
        private readonly Rotator rotator;

        public Enemy(
            PlayerPositionProvider playerPositionProvider,
            EnemyMotor enemyMotor)
        {
            this.playerPositionProvider = playerPositionProvider;
            this.enemyMotor = enemyMotor;
            this.speed = 5;
            this.characterMovement = new CharacterMovement();
            this.rotator = new Rotator();
        }

        public Vector3 GetNextMovement(float deltaSecondsElapsed)
        {
            var playerPosition = this.playerPositionProvider.GetPosition();
            var enemyCurrentPosition = this.enemyMotor.GetPosition();

            var direction = (playerPosition - enemyCurrentPosition);
            direction.y = 0;
            direction *= 0.5f;

            this.characterMovement.SetUp(direction,
                deltaSecondsElapsed,
                this.speed);

            var nextPositionDelta =
                this.characterMovement.GetNextPositionDelta();

            return nextPositionDelta;
        }

        public Quaternion GetNextRotation(float deltaSecondsElapsed)
        {
            return this.rotator.GetRotationTo(this.enemyMotor.GetPosition(),
                this.playerPositionProvider.GetPosition());
        }
    }
}

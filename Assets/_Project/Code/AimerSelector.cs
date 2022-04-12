using UnityEngine;

namespace GraveKiller
{
    public class AimerSelector
    {
        private readonly Rotator rotator;
        private readonly PhysicsRaycast physicsRaycast;
        private readonly PlayerPositionProvider playerPositionProvider;
        private readonly PlayerStats playerStats;
        private Quaternion lastRotation;
        private MovementRequest movementRequest;
        private Vector3[] enemiesFound;

        public AimerSelector(
            PhysicsRaycast physicsRaycast,
            PlayerPositionProvider playerPositionProvider,
            PlayerStats playerStats)
        {
            this.rotator = new Rotator();
            this.lastRotation = Quaternion.identity;
            this.playerStats = playerStats;
            this.physicsRaycast = physicsRaycast;
            this.playerPositionProvider = playerPositionProvider;
            this.movementRequest = new MovementRequest();
        }

        public void SetUp(MovementRequest movementRequest)
        {
            this.movementRequest = movementRequest;
        }

        public Quaternion GetNextRotation()
        {
            var playerPosition = this.playerPositionProvider.GetPosition();
            this.enemiesFound = this.TryGetNearEnemies(playerPosition);

            if (this.enemiesFound.Length > 0)
            {
                return this.GetCloserEnemy(playerPosition);
            }

            if (!this.movementRequest.HasDirection())
            {
                return this.lastRotation;
            }

            return this.GetRotationBasedOnMovementDirection();
        }

        private Quaternion GetRotationBasedOnMovementDirection()
        {
            var movementDirection = this.movementRequest.GetVector3Direction();

            this.lastRotation =
                this.rotator.GetRotationTo(Vector3.zero, movementDirection);

            return this.lastRotation;
        }

        private Quaternion GetCloserEnemy(Vector3 playerPosition)
        {
            Vector3 nearestPosition = default;
            var minSqrDistance = Mathf.Infinity;

            for (var i = 0; i < this.enemiesFound.Length; i++)
            {
                var current = this.enemiesFound[i];

                var sqrDistanceToCenter =
                    (playerPosition - current).sqrMagnitude;

                if (sqrDistanceToCenter < minSqrDistance)
                {
                    minSqrDistance = sqrDistanceToCenter;
                    nearestPosition = current;
                }
            }

            this.lastRotation =
                this.rotator.GetRotationTo(playerPosition, nearestPosition);

            return this.lastRotation;
        }

        private Vector3[] TryGetNearEnemies(Vector3 playerPosition)
        {
            const int enemyLayer = 1 << 7;

            return this.physicsRaycast.GetPositionsOverlappingSphere(
                playerPosition,
                this.playerStats.GetAimingRange(),
                enemyLayer);
        }
    }
}

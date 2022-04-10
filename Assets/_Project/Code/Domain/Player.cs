using UnityEngine;

namespace GraveKiller
{
    public class Player
    {
        private readonly PlayerMotor playerMotor;
        private readonly PlayerStats stats;

        public Player(PlayerMotor playerMotor, PlayerStats stats)
        {
            this.playerMotor = playerMotor;
            this.stats = stats;
        }

        public Vector3 GetNextPosition(
            MovementRequest movementRequest,
            float delta)
        {
            if (!movementRequest.HasDirection())
            {
                return this.GetPosition();
            }

            Vector3 requestedDirection = movementRequest.GetVector3Direction();

            Vector3 deltaPosition =
                this.GetDeltaMovement(delta, requestedDirection);

            Vector3 finalPosition = this.GetPosition() + deltaPosition;

            return finalPosition;
        }

        private Vector3 GetPosition()
        {
            return this.playerMotor.GetPosition();
        }

        private Vector3 GetDeltaMovement(
            float delta,
            Vector3 requestedDirection)
        {
            return requestedDirection * (delta * this.stats.GetSpeed());
        }
    }
}

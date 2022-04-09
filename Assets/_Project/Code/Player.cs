
using System.Numerics;

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

        public Vector2 GetNextPosition(
            MovementRequest movementRequest,
            float delta)
        {
            if (!movementRequest.HasDirection())
            {
                return this.GetPosition();
            }

            Vector2 requestedDirection = movementRequest.direction;

            Vector2 deltaPosition =
                this.GetDeltaMovement(delta, requestedDirection);

            Vector2 finalPosition = this.GetPosition() + deltaPosition;

            return finalPosition;
        }

        private Vector2 GetPosition()
        {
            return this.playerMotor.GetPosition();
        }

        private Vector2 GetDeltaMovement(
            float delta,
            Vector2 requestedDirection)
        {
            return requestedDirection * (delta * this.stats.GetSpeed());
        }
    }
}

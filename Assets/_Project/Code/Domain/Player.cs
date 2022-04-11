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

        private Vector3 GetPosition()
        {
            return this.playerMotor.GetPosition();
        }

        public Vector3 GetNextPositionDelta(
            MovementRequest request,
            float delta)
        {
            var requestedDirection = request.GetVector3Direction();

            if (!request.HasDirection())
            {
                return Vector3.zero;
            }

            return new CharacterMovement(requestedDirection,
                delta,
                this.stats.GetSpeed()).GetNextPositionDelta();
        }
    }
}

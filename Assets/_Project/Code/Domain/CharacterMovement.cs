using UnityEngine;

namespace GraveKiller
{
    public class CharacterMovement
    {
        private Vector3 requestedDirection;
        private float delta;
        private float speed;

        public CharacterMovement(Vector3 requestedDirection, float delta, float speed)
        {
            this.requestedDirection = requestedDirection.normalized;
            this.delta = delta;
            this.speed = speed;
        }

        public Vector3 GetNextPositionDelta()
        {
            return this.requestedDirection * (this.delta * this.speed);
        }
    }
}

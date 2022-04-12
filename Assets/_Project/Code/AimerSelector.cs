using UnityEngine;

namespace GraveKiller
{
    public class AimerSelector
    {
        private MovementRequest movementRequest;
        private readonly Rotator rotator;

        public AimerSelector()
        {
            this.rotator = new Rotator();
        }

        public void SetUp(MovementRequest movementRequest)
        {
            this.movementRequest = movementRequest;
        }

        public Quaternion GetNextRotation()
        {
            var movementDirection = this.movementRequest.GetVector3Direction();

            return this.rotator.GetRotationTo(Vector3.zero, movementDirection);
        }
    }
}

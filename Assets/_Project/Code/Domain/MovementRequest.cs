using UnityEngine;
namespace GraveKiller
{
    public class MovementRequest
    {
        private const double PRECISION = 0.02;
        private Vector2 direction;

        public MovementRequest()
        {
            this.direction = new Vector2();
        }

        public void SetHorizontal(float amount)
        {
            this.direction.x += amount;
        }
        
        public void SetForward(float amount)
        {
            this.direction.y += amount;
        }

        public float GetHorizontal()
        {
            return this.direction.x;
        }
        
        public float GetForward()
        {
            return this.direction.y;
        }

        public Vector3 GetVector3Direction()
        {
            return new Vector3(this.direction.x, 0, this.direction.y);
        }
        
        public bool HasDirection()
        {
            return this.direction.SqrMagnitude() > PRECISION;
        }
    }
}

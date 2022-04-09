
using System.Numerics;

namespace GraveKiller
{
    public class MovementRequest
    {
        private const double PRECISION = 0.02;
        public Vector2 direction;

        public MovementRequest()
        {
            this.direction = new Vector2();
        }
        
        public bool HasDirection()
        {
            return this.direction.LengthSquared() > PRECISION;
        }
    }
}

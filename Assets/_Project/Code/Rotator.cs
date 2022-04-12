using UnityEngine;

namespace GraveKiller
{
    public class Rotator
    {
        public Quaternion GetRotationTo(Vector3 origin, Vector3 target)
        {
            var direction = target - origin;

            return Quaternion.LookRotation(direction, Vector3.up);
        }
    }
}

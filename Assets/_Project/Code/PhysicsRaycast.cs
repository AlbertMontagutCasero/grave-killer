using UnityEngine;

namespace GraveKiller
{
    public interface PhysicsRaycast
    {
        public Vector3[] GetPositionsOverlappingSphere(
            Vector3 origin,
            float radius,
            int layerMask = Physics.AllLayers);
    }
}

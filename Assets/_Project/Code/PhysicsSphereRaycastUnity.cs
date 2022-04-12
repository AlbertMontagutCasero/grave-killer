using System;
using UnityEngine;

namespace GraveKiller
{
    public class PhysicsSphereRaycastUnity : PhysicsRaycast
    {
        private readonly Collider[] foundColliders;
        private Vector3[] positions;

        public PhysicsSphereRaycastUnity()
        {
            this.positions = new Vector3[15];
            this.foundColliders = new Collider[15];
        }
        
        public Vector3[] GetPositionsOverlappingSphere(
            Vector3 origin,
            float radius,
            int layerMask = Physics.AllLayers)
        {
            var amountFound = Physics.OverlapSphereNonAlloc(origin,
                radius,
                this.foundColliders,
                layerMask);

            return amountFound == 0 ? this.GetVoidPositionsArray() : this.GetPositionsBasedOnCollidersFound(amountFound);
        }

        private Vector3[] GetPositionsBasedOnCollidersFound(int amountFound)
        {
            Array.Resize(ref this.positions, amountFound);

            for (var i = 0; i < amountFound; i++)
            {
                this.positions[i] = this.foundColliders[i].transform.position;
            }

            return this.positions;
        }

        private Vector3[] GetVoidPositionsArray()
        {
            return Array.Empty<Vector3>();
        }
    }
}

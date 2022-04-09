using System.Collections.Generic;
using UnityEngine;

namespace GraveKiller
{
    public class EnemyJiggly : MonoBehaviour, Updateable
    {
        private int currentIndexIteration;
        
        private static List<Vector3> movements = new List<Vector3> {
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0),
            new Vector3(-1, 0, 0)
        };
        
        private List<Vector3> movementQueue = new List<Vector3>(movements);

        public void ManagedUpdate(float delta)
        {
            var current = this.movementQueue[this.currentIndexIteration];
            this.transform.localPosition += current;
            this.currentIndexIteration = (this.currentIndexIteration + 1) % this.movementQueue.Count;
        }
    }
}

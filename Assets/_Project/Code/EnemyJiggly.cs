using System.Collections.Generic;
using UnityEngine;

namespace GraveKiller
{
    public interface Updateable
    {
        void ManagedUpdate(float delta);
    }

    public class EnemyJiggly : MonoBehaviour, Updateable
    {
        private static List<Vector3> movements = new List<Vector3> {
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, -1, 0),
            new Vector3(-1, 0, 0)
        };
        private Queue<Vector3> movementQueue = new Queue<Vector3>(movements);

        public void ManagedUpdate(float delta)
        {
            var current = this.movementQueue.Dequeue();
            this.transform.localPosition += current;
            this.movementQueue.Enqueue(current);
        }
    }
}

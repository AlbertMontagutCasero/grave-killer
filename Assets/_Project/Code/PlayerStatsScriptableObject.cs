using UnityEngine;

namespace GraveKiller
{
    [CreateAssetMenu]
    public class PlayerStatsScriptableObject : ScriptableObject, PlayerStats
    {
        [SerializeField]
        private float speed = 10;
        
        [SerializeField]
        private float aimingRange = 20;
        
        public float GetSpeed()
        {
            return this.speed;
        }

        public float GetAimingRange()
        {
            return this.aimingRange;
        }
    }
}

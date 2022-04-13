using UnityEngine;

namespace GraveKiller
{
    [CreateAssetMenu]
    public class PlayerStatsScriptableObject : ScriptableObject, PlayerStats
    {
        [SerializeField]
        private float speed = 10;
        
        [SerializeField]
        private float aimingRadius = 20;
        
        public float GetSpeed()
        {
            return this.speed;
        }

        public float GetAimingRadius()
        {
            return this.aimingRadius;
        }
    }
}

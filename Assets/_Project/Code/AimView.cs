using UnityEngine;

namespace GraveKiller
{
    public class AimView: MonoBehaviour
    {
        [SerializeField]
        private PlayerStatsScriptableObject playerStats;

        [SerializeField]
        private SpriteRenderer aimView;
        
        private void Start()
        {
            this.aimView.transform.localScale = Vector3.one * this.playerStats.GetAimingRadius() * 2;
        }
    }
}

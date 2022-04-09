using UnityEngine;

namespace GraveKiller
{
    public class GameView : MonoBehaviour
    {
        [SerializeField]
        private PlayerView playerView;
        
        [SerializeField]
        private GameObject spawnPosition;

        private PlayerView instantiatedPlayerView;

        private void Start()
        {
            this.SpawnPlayer();
        }

        private Vector3 GetSpawnPosition()
        {
            return this.spawnPosition.transform.position;
        }

        public void SpawnPlayer()
        {
            this.instantiatedPlayerView = Instantiate(this.playerView, this.GetSpawnPosition(), Quaternion.identity);
        }

        private void Update()
        {
            var delta = Time.deltaTime;
            this.instantiatedPlayerView.ManagedUpdate(delta);
        }
    }
}

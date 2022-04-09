using UnityEngine;

namespace GraveKiller
{
    public class GameView : MonoBehaviour
    {
        [SerializeField]
        private PlayerView playerView;

        [SerializeField]
        private EnemyGeneratorView enemyGeneratorPrefab;

        [SerializeField]
        private GameObject spawnPosition;

        private PlayerView instantiatedPlayerView;
        private EnemyGeneratorView instantiatedEnemyGenerator;

        private void Start()
        {
            this.SpawnPlayer();
            this.SpawnEnemyGenerator();
        }

        private void SpawnEnemyGenerator()
        {
            this.instantiatedEnemyGenerator =
                Instantiate(this.enemyGeneratorPrefab);
        }

        private Vector3 GetSpawnPosition()
        {
            return this.spawnPosition.transform.position;
        }

        public void SpawnPlayer()
        {
            this.instantiatedPlayerView = Instantiate(this.playerView,
                this.GetSpawnPosition(),
                Quaternion.identity);
        }

        private void Update()
        {
            var delta = Time.deltaTime;
            this.instantiatedPlayerView.ManagedUpdate(delta);
            this.instantiatedEnemyGenerator.ManagedUpdate(delta);
        }
    }
}

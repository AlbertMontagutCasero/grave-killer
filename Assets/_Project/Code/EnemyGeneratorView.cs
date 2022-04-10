using System.Collections.Generic;
using UnityEngine;

namespace GraveKiller
{
    public class EnemyGeneratorView : MonoBehaviour, EnemyGeneratorMotor
    {
        [SerializeField]
        private List<GameObject> spawnPoints = new List<GameObject>();

        [SerializeField]
        private float spawnEvery = 5f;

        [SerializeField]
        private EnemyView enemy;

        private EnemyGenerator enemyGenerator;
        private List<EnemyView> instantiatedEnemies;

        private void Awake()
        {
            this.instantiatedEnemies = new List<EnemyView>();
            var spawnPointsVectors = this.GetSpawnPointsVectors();

            this.enemyGenerator = new EnemyGenerator(this.spawnEvery,
                this,
                spawnPointsVectors);
        }

        private List<Vector2> GetSpawnPointsVectors()
        {
            var spawnVectorPositions = new List<Vector2>();

            for (var i = 0; i < this.spawnPoints.Count; i++)
            {
                var current = this.spawnPoints[i];

                var spawnPosition =
                    current.transform.position;

                spawnVectorPositions.Add(spawnPosition);
            }

            return spawnVectorPositions;
        }

        public void ManagedUpdate(float delta)
        {
            this.MoveEnemies(delta);   
            this.enemyGenerator.AddTime(delta);
        }

        private void MoveEnemies(float delta)
        {
            for (int i = 0; i < this.instantiatedEnemies.Count; i++)
            {
                var current = this.instantiatedEnemies[i];
                current.ManagedUpdate(delta);
            }
        }

        public void GenerateNewEnemy()
        {
            var spawnPoint = this.enemyGenerator.GetSpawnPoint();
            var instantiatedEnemy = Instantiate(this.enemy, spawnPoint, Quaternion.identity);
            this.instantiatedEnemies.Add(instantiatedEnemy);
        }
    }
}

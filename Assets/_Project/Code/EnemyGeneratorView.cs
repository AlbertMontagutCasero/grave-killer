using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace GraveKiller
{
    public class EnemyGeneratorView : MonoBehaviour, EnemyGeneratorMotor
    {
        [SerializeField]
        private List<GameObject> spawnPoints = new List<GameObject>();

        [SerializeField]
        private float spawnEvery = 5f;

        [SerializeField]
        private GameObject enemy;

        private EnemyGenerator enemyGenerator;

        private void Awake()
        {
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
                    current.transform.position.ToSystemVector2();

                spawnVectorPositions.Add(spawnPosition);
            }

            return spawnVectorPositions;
        }

        public void ManagedUpdate(float delta)
        {
            this.enemyGenerator.AddTime(delta);
        }

        public void GenerateNewEnemy()
        {
            var spawnPoint = this.enemyGenerator.GetSpawnPoint().ToUnityVector3();
            var instantiatedEnemy = Instantiate(this.enemy, spawnPoint, Quaternion.identity);
        }
    }
}

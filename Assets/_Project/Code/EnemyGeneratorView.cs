using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace GraveKiller
{
    public class EnemyGeneratorView : MonoBehaviour, EnemyGeneratorMotor
    {
        [SerializeField]
        private EnemyJiggly enemyPrefab;
        private List<EnemyJiggly> enemiesView;

        private void Awake()
        {
            this.enemiesView = new List<EnemyJiggly>();
        }

        private void Start()
        {
            new EnemyGenerator(this).SpawnEnemiesTest();
        }

        public IEnumerable<Vector3> GetEnemyPositions()
        {
            for (var i = 0; i < this.enemiesView.Count; i++)
            {
                var current = this.enemiesView[i];

                UnityEngine.Vector3 transformPosition =
                    current.transform.position;

                yield return new Vector3(transformPosition.x,
                    transformPosition.y,
                    transformPosition.z);
            }
        }

        public void GenerateNewEnemy(Vector3 position)
        {
            var instantiated = Instantiate(this.enemyPrefab,
                new UnityEngine.Vector3(position.X,  position.Z, 0),
                Quaternion.identity);

            this.enemiesView.Add(instantiated);
        }

        private void Update()
        {
            var delta = Time.deltaTime;
            for (var i = 0; i < this.enemiesView.Count; i++)
            {
                var current = this.enemiesView[i];
                current.ManagedUpdate(delta);
            }
        }
    }
}

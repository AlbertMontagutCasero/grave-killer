using System.Collections.Generic;
using UnityEngine;

namespace GraveKiller
{
    public class EnemyGeneratorView : MonoBehaviour, EnemyGeneratorMotor
    {
        [SerializeField]
        private float spawnEvery = 5f;

        [SerializeField]
        private EnemyView enemy;

        private EnemyGenerator enemyGenerator;
        private List<EnemyView> instantiatedEnemies;
        private PlayerPositionProvider playerPositionProvider;

        private void Awake()
        {
            this.instantiatedEnemies = new List<EnemyView>();

            this.enemyGenerator = new EnemyGenerator(this.spawnEvery,
                this);
            
            this.playerPositionProvider = GameControllerLocator.GetInstance()
                .GetController<PlayerPositionProvider>();
        }

        public void Update()
        {
            float delta = Time.deltaTime;
            this.MoveEnemies(Time.deltaTime);

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

            var instantiatedEnemy =
                Instantiate(this.enemy, spawnPoint, Quaternion.identity);

            instantiatedEnemy.SetUp(this.playerPositionProvider);
            this.instantiatedEnemies.Add(instantiatedEnemy);
        }
    }
}

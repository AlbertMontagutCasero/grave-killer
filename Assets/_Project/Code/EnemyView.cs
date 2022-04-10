using UnityEngine;

namespace GraveKiller
{
    public class EnemyView: MonoBehaviour, EnemyMotor
    {
        private Enemy enemy;
        private bool spawned;

        private void Awake()
        {
            var playerPositionProvider = GameControllerLocator.GetInstance()
                .GetController<PlayerPositionProvider>();

            this.enemy = new Enemy(playerPositionProvider,this);
            this.spawned = true;
        }

        public void ManagedUpdate(float delta)
        {
            if (!this.spawned)
            {
                return;
            }
            
            this.transform.position = this.enemy.GetNextMovement(delta);
        }

        public Vector3 GetPosition()
        {
            return this.transform.position;
        }
    }
}

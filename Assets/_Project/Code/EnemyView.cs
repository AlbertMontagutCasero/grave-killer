using UnityEngine;

namespace GraveKiller
{
    public class EnemyView: MonoBehaviour, EnemyMotor
    {
        private Enemy enemy;

        private void Awake()
        {
            var playerPositionProvider = GameControllerLocator.GetInstance()
                .GetController<PlayerPositionProvider>();

            this.enemy = new Enemy(playerPositionProvider,this);
        }

        public void ManagedUpdate(float delta)
        {
            this.transform.position = this.enemy.GetNextMovement(delta);
        }

        public Vector2 GetPosition()
        {
            return this.transform.position;
        }
    }
}

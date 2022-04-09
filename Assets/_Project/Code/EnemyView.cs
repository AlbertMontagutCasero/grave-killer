using UnityEngine;
using Vector2 = System.Numerics.Vector2;

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
            this.transform.position = this.enemy.GetNextMovement(delta).ToUnityVector3();
        }

        public Vector2 GetPosition()
        {
            return this.transform.position.ToSystemVector2();
        }
    }

    public interface EnemyMotor
    {
        Vector2 GetPosition();
    }

    public interface PlayerPositionProvider
    {
        Vector2 GetPosition();
    }
}

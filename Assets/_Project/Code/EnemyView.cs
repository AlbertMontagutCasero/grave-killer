using UnityEngine;

namespace GraveKiller
{
    public class EnemyView: MonoBehaviour, EnemyMotor
    {
        private Enemy enemy;
        private CharacterController characterController;

        private void Awake()
        {
            this.characterController = this.GetComponent<CharacterController>();
        }

        public void SetUp()
        {
            var playerPositionProvider = GameControllerLocator.GetInstance()
                .GetController<PlayerPositionProvider>();

            this.enemy = new Enemy(playerPositionProvider,this);
        }

        public void ManagedUpdate(float delta)
        {
            this.characterController.Move(this.enemy.GetNextMovement(delta));
            this.transform.rotation = this.enemy.GetNextRotation(delta);
        }

        public Vector3 GetPosition()
        {
            return this.transform.position;
        }
    }
}

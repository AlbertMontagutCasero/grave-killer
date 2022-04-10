using UnityEngine;

namespace GraveKiller
{
    public class PlayerView : MonoBehaviour, PlayerMotor
    {
        private Player player;

        private void Awake()
        {
            var playerSpeed = 5;
            this.player = new Player(this, new PlayerStats(playerSpeed));
            
            GameControllerLocator.GetInstance().RegisterController(this);
        }

        public Vector2 GetPosition()
        {
            return this.transform.position;
        }

        public void ManagedUpdate(float delta)
        {
            this.DetectPlayerInput(delta);
        }
        
        private void DetectPlayerInput(float delta)
        {
            var movementRequest = new MovementRequest();

            if (Input.GetKey(KeyCode.D))
            {
                movementRequest.direction.x += 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movementRequest.direction.x -= 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                movementRequest.direction.y += 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movementRequest.direction.y -= 1;
            }

            this.transform.position = this.player
                .GetNextPosition(movementRequest, delta);
        }
    }
}

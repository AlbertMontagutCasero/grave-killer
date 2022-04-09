using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using Vector3 = System.Numerics.Vector3;

namespace GraveKiller
{
    public class PlayerView : MonoBehaviour, PlayerMotor
    {
        private Player player;

        private void Awake()
        {
            var playerSpeed = 5;
            this.player = new Player(this, new PlayerStats(playerSpeed));
        }

        public Vector2 GetPosition()
        {
            return this.transform.position.ToSystemVector2();
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
                movementRequest.direction.X += 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movementRequest.direction.X -= 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                movementRequest.direction.Y += 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movementRequest.direction.Y -= 1;
            }

            this.transform.position = this.player
                .GetNextPosition(movementRequest, delta)
                .ToUnityVector3();
        }
        
    }
}

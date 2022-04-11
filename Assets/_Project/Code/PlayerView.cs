using UnityEngine;

namespace GraveKiller
{
    public class PlayerView : MonoBehaviour, PlayerMotor
    {
        private Player player;
        private MovementRequest movementRequest;
        
        private CharacterController characterController;

        private void Awake()
        {
            this.characterController = this.GetComponent<CharacterController>();
            
            var playerSpeed = 10f;
            this.player = new Player(this, new PlayerStats(playerSpeed));
        }

        public void RequestMovement(MovementRequest request)
        {
            if (this.movementRequest == null)
            {
                this.movementRequest = request;
            }
        }

        public Vector3 GetPosition()
        {
            return this.transform.position;
        }

        private void FixedUpdate()
        {
            if (this.IsMovementRequestConsumed())
            {
                return;
            }

            this.MovePlayer();
            this.ConsumeRequest();
        }

        private bool IsMovementRequestConsumed()
        {
            return this.movementRequest == null;
        }

        private void MovePlayer()
        {
            var nextPositionIntention =
                this.player.GetNextPositionDelta(this.movementRequest,
                    Time.fixedDeltaTime);

            this.characterController.Move(nextPositionIntention);
        }

        private void ConsumeRequest()
        {
            this.movementRequest = null;
        }
    }
}

using UnityEngine;

namespace GraveKiller
{
    public class GameplayKeyboardInputController: MonoBehaviour
    {
        private PlayerView playerView;

        public void SetUp()
        {
            this.playerView = GameControllerLocator.GetInstance().GetController<PlayerView>();
        }

        private void Update()
        {
            this.GetKeyBoardMovementRequest();
        }

        private void GetKeyBoardMovementRequest()
        {
            var movementRequest = new MovementRequest();

            if (Input.GetKey(KeyCode.D))
            {
                movementRequest.SetHorizontal(1);
            }

            if (Input.GetKey(KeyCode.A))
            {
                movementRequest.SetHorizontal(-1);
            }

            if (Input.GetKey(KeyCode.W))
            {
                movementRequest.SetForward(1);
            }

            if (Input.GetKey(KeyCode.S))
            {
                movementRequest.SetForward(-1);
            }

            if (movementRequest.HasDirection())
            {
                this.playerView.RequestMovement(movementRequest);
            }
        }
    }
}

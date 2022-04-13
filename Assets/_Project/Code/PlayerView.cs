using UnityEngine;

namespace GraveKiller
{
    public class PlayerView : MonoBehaviour, PlayerMotor
    {
        [SerializeField]
        private float rotationSpeed = 20;

        [SerializeField]
        private PlayerStatsScriptableObject playerStats;
        
        private Player player;
        private MovementRequest movementRequest;
        private CharacterController characterController;
        private AimerSelector aimer;
        
        private void Awake()
        {
            this.characterController = this.GetComponent<CharacterController>();

            this.player = new Player(this, this.playerStats);

            this.aimer =
                new AimerSelector(new PhysicsSphereRaycastUnity(), this, this.playerStats);
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
                this.Rotate();

                return;
            }

            this.aimer.SetUp(this.movementRequest);
            this.Rotate();
            this.Move();
            this.ConsumeMovementRequest();
        }

        private void Rotate()
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                this.aimer.GetNextRotation(),
                Time.fixedDeltaTime * this.rotationSpeed);
        }

        private bool IsMovementRequestConsumed()
        {
            return this.movementRequest == null;
        }

        private void Move()
        {
            var nextPositionIntention =
                this.player.GetNextPositionDelta(this.movementRequest,
                    Time.fixedDeltaTime);

            this.characterController.Move(nextPositionIntention);
        }

        private void ConsumeMovementRequest()
        {
            this.movementRequest = null;
        }
    }
}

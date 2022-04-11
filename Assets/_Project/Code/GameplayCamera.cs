using Cinemachine;
using UnityEngine;

namespace GraveKiller
{
    public class GameplayCamera : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera virtualCamera;

        public void SetUp()
        {
            var playerView = GameControllerLocator.GetInstance()
                .GetController<PlayerView>();

            this.virtualCamera.Follow = playerView.transform;
        }
    }
}

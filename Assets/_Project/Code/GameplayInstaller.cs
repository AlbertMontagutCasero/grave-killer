using UnityEngine;

namespace GraveKiller
{
    public class GameplayInstaller : MonoBehaviour
    {
        [SerializeField]
        private PlayerView playerView;

        [SerializeField]
        private EnemyGeneratorView enemyGeneratorPrefab;

        [SerializeField]
        private GameplayKeyboardInputController
            gameplayKeyboardInputControllerPrefab;

        [SerializeField]
        private GameObject spawnPosition;
        
        [SerializeField]
        private GameplayCamera gameplayCameraPrefab;
        
        private void Awake()
        {
            var gameControllerLocator = GameControllerLocator.GetInstance();

            var keyboardInputController = this.SpawnGameplayKeyboardInputController();
            var player = this.SpawnPlayer();
            var enemy = this.SpawnEnemyGenerator();
            var gameplayCamera = this.SpawnCamera();

            gameControllerLocator.RegisterController(player);
            gameControllerLocator.RegisterController<PlayerPositionProvider>(player);
            gameControllerLocator.RegisterController(enemy);
            gameControllerLocator.RegisterController(keyboardInputController);
            
            keyboardInputController.SetUp();
            gameplayCamera.SetUp();
        }

        private GameplayCamera SpawnCamera()
        {
            return Instantiate(this.gameplayCameraPrefab);;
        }

        private GameplayKeyboardInputController SpawnGameplayKeyboardInputController()
        {
            return Instantiate(this.gameplayKeyboardInputControllerPrefab);
        }

        private PlayerView SpawnPlayer()
        {
            return Instantiate(this.playerView,
                this.GetSpawnPosition(),
                Quaternion.identity);
        }

        private EnemyGeneratorView SpawnEnemyGenerator()
        {
            return Instantiate(this.enemyGeneratorPrefab);
        }

        private Vector3 GetSpawnPosition()
        {
            return this.spawnPosition.transform.position;
        }
    }
}

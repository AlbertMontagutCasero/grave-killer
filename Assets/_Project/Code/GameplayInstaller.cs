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
        
        private void Awake()
        {
            var gameControllerLocator = GameControllerLocator.GetInstance();

            var keyboardInputController = this.SpawnGameplayKeyboardInputController();
            var player = this.SpawnPlayer();
            var enemy = this.SpawnEnemyGenerator();

            gameControllerLocator.RegisterController(player);
            gameControllerLocator.RegisterController<PlayerPositionProvider>(player);
            gameControllerLocator.RegisterController(enemy);
            gameControllerLocator.RegisterController(keyboardInputController);
            
            keyboardInputController.SetUp();
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

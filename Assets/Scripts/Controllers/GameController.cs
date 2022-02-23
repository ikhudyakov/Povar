using Controllers.GameInput;
using Models;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Controllers
{
    public class GameController : BaseController
    {
        private PlayerController _playerController;
        private PauseMenuController _pauseMenuController;

        public GameController(string playerAnimationConfigResource, string playerViewResource, ProfilePlayer profilePlayer, Transform parent)
        {
            Addressables.LoadAssetAsync<GameObject>("Prefabs/TestLevel").Completed += OnLoadPrefabDone;
            _pauseMenuController = new PauseMenuController(profilePlayer, parent);
            _playerController = new PlayerController(playerAnimationConfigResource, playerViewResource, _pauseMenuController, parent);
        }

        private void OnLoadPrefabDone(AsyncOperationHandle<GameObject> obj)
        {
            var prefab = GameObject.Instantiate(obj.Result);
            AddGameObjects(prefab.gameObject);
        }

        public override void Dispose()
        {
            base.Dispose();
            _playerController?.Dispose();
            _pauseMenuController?.Dispose();
        }
    }
}

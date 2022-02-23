using Configs;
using Controllers.GameInput;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Utils;
using Views;

namespace Controllers
{
    public class PlayerController : BaseController
    {
        private readonly string _playerViewResource;
        private PlayerView _playerView;
        private BaseInputController _inputController;
        private PauseMenuController _pauseMenuController;
        private ContactPoller _contactPoller;
        private CameraController _cameraConctroller;
        private SpriteAnimatorConfig _playerConfig;
        private SpriteAnimatorController _playerAnimator;

        public PlayerView PlayerView => _playerView;

        public PlayerController(string playerAnimationConfigResource, string playerViewResource, PauseMenuController pauseMenuController, Transform parent) : base()
        {
            _playerViewResource = playerViewResource;
            _pauseMenuController = pauseMenuController;
            _parent = parent;
            Addressables.LoadAssetAsync<SpriteAnimatorConfig>(playerAnimationConfigResource).Completed += OnLoadAnimationConfigDone;
        }

        private void OnLoadAnimationConfigDone(AsyncOperationHandle<SpriteAnimatorConfig> obj)
        {
            _playerConfig = obj.Result;
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            Addressables.LoadAssetAsync<GameObject>(_playerViewResource).Completed += OnLoadPrefabDone;
        }

        private void OnLoadPrefabDone(AsyncOperationHandle<GameObject> obj)
        {
            var temp = obj.Result;
            var prefab = temp.GetComponent<PlayerView>();
            _playerView = GameObject.Instantiate(prefab);
            AddGameObjects(_playerView.gameObject);
            _contactPoller = new ContactPoller(_playerView._collider);
            _cameraConctroller = new CameraController(PlayerView._transform, Camera.main.transform);
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                _inputController = new PCInputController(_playerView, _playerAnimator, _contactPoller, _pauseMenuController);
            if (Application.platform == RuntimePlatform.Android)
                _inputController = new MobileInputController(_playerView, _playerAnimator, _contactPoller, _parent, _pauseMenuController);
        }

        public override void Dispose()
        {
            base.Dispose();
            _playerAnimator?.Dispose();
            _contactPoller?.Dispose();
            _cameraConctroller?.Dispose();
            _inputController?.Dispose();
        }
    }
}
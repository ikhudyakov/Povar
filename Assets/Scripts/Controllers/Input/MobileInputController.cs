using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Utils;
using Views;
using Views.GameInput;

namespace Controllers.GameInput
{
    public class MobileInputController : BaseInputController
    {
        public MobileInputController(
            PlayerView playerView, 
            SpriteAnimatorController playerAnimator, 
            ContactPoller contactPoller, 
            Transform parent, 
            PauseMenuController pauseMenuController) : base(
                playerView, 
                playerAnimator, 
                contactPoller, 
                pauseMenuController)
        {
            Addressables.LoadAssetAsync<GameObject>("Prefabs/MobileGameInput").Completed += OnLoadInputViewDone;
            _parent = parent;
        }

        private void OnLoadInputViewDone(AsyncOperationHandle<GameObject> obj)
        {
            var temp = obj.Result;
            var prefab = temp.GetComponent<BaseInputView>();
            _inputView = GameObject.Instantiate(prefab, _parent);
            AddGameObjects(_inputView.gameObject);
            _inputView.Init(_pauseMenuView);
            _isDone = true;
        }
    }
}

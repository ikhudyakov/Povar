using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Utils;
using Views;
using Views.GameInput;

namespace Controllers.GameInput
{
    public class PCInputController : BaseInputController
    {
        public PCInputController(
            PlayerView playerView, 
            SpriteAnimatorController playerAnimator, 
            ContactPoller contactPoller, 
            PauseMenuController pauseMenuController) : base(
                playerView, 
                playerAnimator, 
                contactPoller, 
                pauseMenuController)
        {
            Addressables.LoadAssetAsync<GameObject>("Prefabs/PCGameInput").Completed += OnLoadInputViewDone;
        }

        private void OnLoadInputViewDone(AsyncOperationHandle<GameObject> obj)
        {
            var temp = obj.Result;
            var prefab = temp.GetComponent<BaseInputView>();
            _inputView = GameObject.Instantiate(prefab);
            AddGameObjects(_inputView.gameObject);
            _inputView.Init(_pauseMenuView);
            _isDone = true;
        }
    }
}

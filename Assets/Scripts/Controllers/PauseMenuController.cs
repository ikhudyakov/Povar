using Models;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Views;

namespace Controllers.GameInput
{
    public class PauseMenuController : BaseController
    {
        private PauseMenuView _pauseMenuView;
        private readonly ProfilePlayer _profilePlayer;

        public PauseMenuView PauseMenuView { get => _pauseMenuView; set => _pauseMenuView = value; }

        public PauseMenuController(ProfilePlayer profilePlayer, Transform parent) : base()
        {
            Addressables.LoadAssetAsync<GameObject>("Prefabs/PauseMenu").Completed += OnLoadInputViewDone;
            _parent = parent;
            _profilePlayer = profilePlayer;
        }

        private void OnLoadInputViewDone(AsyncOperationHandle<GameObject> obj)
        {
            var temp = obj.Result;
            var prefab = temp.GetComponent<PauseMenuView>();
            _pauseMenuView = GameObject.Instantiate(prefab, _parent);
            AddGameObjects(_pauseMenuView.gameObject);
            _pauseMenuView.Init(_profilePlayer);
            _pauseMenuView.gameObject.SetActive(false);
        }
    }
}

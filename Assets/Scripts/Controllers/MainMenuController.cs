using Models;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Views;

namespace Controllers
{
    public class MainMenuController : BaseController
    {
        private MainMenuView _mainMenuView;
        private ProfilePlayer _profilePlayer;

        public MainMenuController(string mainMenuViewResource, ProfilePlayer profilePlayer, Transform parent)
        {
            Addressables.LoadAssetAsync<GameObject>(mainMenuViewResource).Completed += OnLoadInputViewDone;
            _profilePlayer = profilePlayer;
            _parent = parent;
        }

        private void OnLoadInputViewDone(AsyncOperationHandle<GameObject> obj)
        {
            var temp = obj.Result;
            var prefab = temp.GetComponent<MainMenuView>();
            _mainMenuView = GameObject.Instantiate(prefab, _parent);
            AddGameObjects(_mainMenuView.gameObject);
            _mainMenuView.Init(StartGame, Reward, Shop, Settings);
        }

        private void Settings()
        {

        }

        private void Shop()
        {

        }

        private void Reward()
        {
            
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
        }
    }
}

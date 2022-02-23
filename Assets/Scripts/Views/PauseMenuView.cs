using Models;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Views
{
    public class PauseMenuView : BaseView
    {
        [SerializeField] Button _backButton;
        [SerializeField] Button _mainMenuButton;
        private ProfilePlayer _profilePlayer;

        public void Init(ProfilePlayer profilePlayer)
        {
            base.Init();
            _profilePlayer = profilePlayer;
            _backButton.AddListener(ClosePauseMenu);
            _mainMenuButton.AddListener(ShowMainMenu);
        }

        private void ShowMainMenu()
        {
            _profilePlayer.CurrentState.Value = GameState.MainMenu;
        }

        private void ClosePauseMenu()
        {
            this.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _backButton.RemoveAllListeners();
            _mainMenuButton.RemoveAllListeners();
        }
    }
}

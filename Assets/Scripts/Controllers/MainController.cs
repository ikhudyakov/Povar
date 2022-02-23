using Models;
using UnityEngine;

namespace Controllers
{
    public class MainController : BaseController
    {
        private ProfilePlayer _profilePlayer;
        private MainMenuController _mainMenuController;
        private GameController _gameController;

        private string _mainMenuViewResource = "Prefabs/MainMenu";
        private string _playerViewResource = "Prefabs/Player";
        private string _playerAnimationConfigResource = "Configs/PowarAnimationConfig";

        public Transform Parent { get; set; }

        public MainController(ProfilePlayer profilePlayer) : base()
        {
            _profilePlayer = profilePlayer;
            _profilePlayer.CurrentState.Subscribe(OnStateChanged);
        }

        public void OnStateChanged(GameState state)
        {
            switch (state)
            {
                case GameState.None:
                    _mainMenuController?.Dispose();
                    _gameController?.Dispose();
                    break;
                case GameState.MainMenu:
                    _mainMenuController = new MainMenuController(_mainMenuViewResource, _profilePlayer, Parent);
                    _gameController?.Dispose();
                    break;
                case GameState.Game:
                    _mainMenuController?.Dispose();
                    _gameController = new GameController(_playerAnimationConfigResource, _playerViewResource, _profilePlayer, Parent);
                    break;
                case GameState.Reward:
                    _mainMenuController?.Dispose();
                    _gameController?.Dispose();
                    break;
                case GameState.Shop:
                    _mainMenuController?.Dispose();
                    _gameController?.Dispose();
                    break;
                case GameState.Setings:
                    _mainMenuController?.Dispose();
                    _gameController?.Dispose();
                    break;
                default:
                    break;
            }
        }
    }
}
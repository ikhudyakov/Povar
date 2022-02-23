using Controllers;
using Models;
using UnityEngine;

namespace Root
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private MainController _mainController;
        [SerializeField] private ProfilePlayer _profilePlayer;
        [SerializeField] private Transform _parent;

        private void Start()
        {
            _profilePlayer = new ProfilePlayer();
            _mainController = new MainController(_profilePlayer);
            _mainController.Parent = _parent;
            _profilePlayer.CurrentState.Value = GameState.MainMenu;
        }

        private void Update()
        {
            
        }
    }
}
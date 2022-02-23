using UnityEngine;

namespace Views.GameInput
{
    public class BaseInputView : BaseView
    {
        private PauseMenuView _pauseMenuView;

        public float XAxisInput { get; set; }
        public bool IsJump { get; set; }

        public virtual void Init(PauseMenuView pauseMenuView)
        {
            base.Init();
            _pauseMenuView = pauseMenuView;
        }

        internal void ShowPauseMenu()
        {
            _pauseMenuView?.gameObject.SetActive(!_pauseMenuView.gameObject.activeSelf);
        }
    }
}
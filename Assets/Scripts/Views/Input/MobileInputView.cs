using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils;

namespace Views.GameInput
{
    public class MobileInputView : BaseInputView
    {
        [SerializeField] private EventTrigger _leftTrigger;
        [SerializeField] private EventTrigger _rightTrigger;
        [SerializeField] private EventTrigger _jumpTrigger;
        [SerializeField] private Button _pauseButton;

        public override void Init(PauseMenuView pauseMenuView)
        {
            base.Init(pauseMenuView);
            _leftTrigger.AddListener(EventTriggerType.PointerDown, MoveLeft);
            _leftTrigger.AddListener(EventTriggerType.PointerUp, ResetMove);
            _rightTrigger.AddListener(EventTriggerType.PointerDown, MoveRight);
            _rightTrigger.AddListener(EventTriggerType.PointerUp, ResetMove);
            _jumpTrigger.AddListener(EventTriggerType.PointerDown, Jump);
            _jumpTrigger.AddListener(EventTriggerType.PointerUp, ResetJump);
            _pauseButton.AddListener(ShowPauseMenu);
        }

        private void ResetJump(PointerEventData obj)
        {
            IsJump = false;
        }

        private void ResetMove(PointerEventData obj)
        {
            XAxisInput = 0.0f;
        }

        public void MoveLeft(BaseEventData pointData)
        {
            XAxisInput = -1.0f;
        }

        public void MoveRight(BaseEventData pointData)
        {
            XAxisInput = 1.0f;
        }

        public void Jump(BaseEventData pointData)
        {
            IsJump = true;
        }

        private void OnDestroy()
        {
            _pauseButton.RemoveAllListeners();
        }
    }
}
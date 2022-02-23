using Configs;
using UnityEngine;
using Utils;
using Views;
using Views.GameInput;

namespace Controllers.GameInput
{
    public class BaseInputController : BaseController
    {
        internal PlayerView _playerView;
        internal SpriteAnimatorController _playerAnimator;
        internal ContactPoller _contactPoller;
        internal BaseInputView _inputView;
        internal PauseMenuView _pauseMenuView;
        internal float _xAxisInput;
        internal float _walkSpeed;
        internal float _animationSpeed;
        internal float _movingTreshold;
        internal float _jumpForce;
        internal float _jumpTreshold;
        internal float _yVelocity;
        internal float _xVelocity;
        internal bool _isJump;
        internal bool _isMoving;
        internal bool _isDone;
        internal readonly Vector3 _leftScale = new Vector3(-1, 1, 1);
        internal readonly Vector3 _rightScale = new Vector3(1, 1, 1);

        public BaseInputController(PlayerView playerView, SpriteAnimatorController playerAnimator, ContactPoller contactPoller, PauseMenuController pauseMenuController)
        {
            _walkSpeed = 100f;
            _animationSpeed = 30f;
            _movingTreshold = 0.1f;
            _jumpForce = 5f;
            _jumpTreshold = 1f;
            _yVelocity = 0f;
            _xVelocity = 0f;
            _playerView = playerView;
            _playerAnimator = playerAnimator;
            _contactPoller = contactPoller;
            _pauseMenuView = pauseMenuController.PauseMenuView;
            _playerAnimator?.StartAnimation(_playerView._spriteRenderer, AnimState.Idle, true, _animationSpeed);
        }

        internal void MoveTowards()
        {
            _xVelocity = _walkSpeed * Time.fixedDeltaTime * (_xAxisInput < 0 ? -1 : 1);
            _playerView._rigidbody.velocity = _playerView._rigidbody.velocity.Change(x: _xVelocity);
            _playerView.transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (_isDone)
            {
                _xAxisInput = _inputView.XAxisInput;
                _isJump = _inputView.IsJump;
                _yVelocity = _playerView._rigidbody.velocity.y;
                _isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;

                if (_isMoving)
                {
                    MoveTowards();
                }

                if (_contactPoller.IsGrounded)
                {
                    _playerAnimator.StartAnimation(_playerView._spriteRenderer, _isMoving ? AnimState.Run : AnimState.Idle, true, _animationSpeed);

                    if (_isJump && Mathf.Abs(_yVelocity) <= _jumpTreshold)
                    {
                        _playerView._rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                    }
                }
                else
                {
                    if (Mathf.Abs(_yVelocity) > _jumpTreshold && _yVelocity < 0)
                    {
                        _playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.JumpDown, false, _animationSpeed);
                    }
                    else if (Mathf.Abs(_yVelocity) > _jumpTreshold && _yVelocity > 0)
                    {
                        _playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.JumpUp, false, _animationSpeed);
                    }
                }
            }
        }
    }
}

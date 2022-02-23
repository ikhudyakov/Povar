using UnityEngine;

namespace Controllers
{
    public class CameraController : BaseController
    {
        private float _x;
        private float _y;
        private float _offsetX;
        private float _offsetY;
        private float _camSpeed;

        private Transform _playerTransform;
        private Transform _cameraTransform;

        public CameraController(Transform playerTransform, Transform cameraTransform) : base()
        {
            _playerTransform = playerTransform;
            _cameraTransform = cameraTransform;
            _offsetX = 0f;
            _offsetY = 0.2f;
            _camSpeed = 300.0f;
        }

        public override void OnUpdate()
        {
            if (_playerTransform.position.y > 2.0f)
                _offsetY = Mathf.MoveTowards(_offsetY, -1.2f, 0.004f);
            if (_playerTransform.position.y <= 2.0f && _playerTransform.position.y >= -1.0f)
                _offsetY = Mathf.MoveTowards(_offsetY, 1f, 0.004f);
            if (_playerTransform.position.y < -1.0f)
                _offsetY = Mathf.MoveTowards(_offsetY, 1.7f, 0.004f);
            _x = _playerTransform.position.x;
            _y = _playerTransform.position.y;
            MoveCamera();
        }

        private void MoveCamera()
        {
            _cameraTransform.position = Vector3.Lerp(
                _cameraTransform.position,
                new Vector3(
                    _x + _offsetX, _y + _offsetY, 
                    _cameraTransform.position.z),
                Time.deltaTime * _camSpeed);
        }
    }
}
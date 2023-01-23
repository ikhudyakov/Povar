using System;
using UnityEngine;

namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        public Transform _transform;
        public SpriteRenderer _spriteRenderer;
        public Collider2D _collider;
        public Rigidbody2D _rigidbody;
        public Transform _gunPoint;
        public GameObject _bullet;

        public Action<PlayerView> OnLevelObjectContact { get; set; }

        private void Start()
        {
            _transform = GetComponent<Transform>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerView player = collision.GetComponent<PlayerView>();
            OnLevelObjectContact?.Invoke(player);
        }
    }
}
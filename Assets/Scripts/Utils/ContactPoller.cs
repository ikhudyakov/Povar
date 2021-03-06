using JoostenProductions;
using System;
using UnityEngine;

namespace Utils
{
    public class ContactPoller : IDisposable
    {
        private ContactPoint2D[] _contacts = new ContactPoint2D[10];

        private const float _collTreshold = 0.6f;
        private int _contactCount;
        private Collider2D _collider2D;

        public bool IsGrounded { get; private set; }
        public bool HasLeftContact { get; private set; }
        public bool HasRightContact { get; private set; }

        public ContactPoller(Collider2D collider)
        {
            _collider2D = collider;
            UpdateManager.SubscribeToUpdate(OnUpdate);
        }

        public void OnUpdate()
        {
            IsGrounded = false;
            HasLeftContact = false;
            HasRightContact = false;

            _contactCount = _collider2D.GetContacts(_contacts);

            for (int i = 0; i < _contactCount; i++)
            {
                if (_contacts[i].normal.y > _collTreshold) IsGrounded = true;
                if (_contacts[i].normal.x > _collTreshold) HasLeftContact = true;
                if (_contacts[i].normal.x > -_collTreshold) HasRightContact = true;
            }
        }

        public void Dispose()
        {
            UpdateManager.UnsubscribeFromUpdate(OnUpdate);
        }
    }
}
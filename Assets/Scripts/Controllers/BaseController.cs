using JoostenProductions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class BaseController : IDisposable
    {
        internal Transform _parent;

        private readonly List<GameObject> _gameObjects = new List<GameObject>();

        public BaseController()
        {
            UpdateManager.SubscribeToUpdate(OnUpdate);
        }

        public virtual void Dispose()
        {
            UpdateManager.UnsubscribeFromUpdate(OnUpdate);

            foreach (var gameObject in _gameObjects)
                GameObject.Destroy(gameObject);

            _gameObjects.Clear();
        }

        public virtual void OnUpdate()
        {

        }

        protected void AddGameObjects(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }
    }
}

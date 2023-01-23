using System;
using UnityEngine;

namespace Controllers
{
    public class GunController : BaseController
    {
        private Transform _gunPoint;
        private GameObject _bullet;

        public GunController(Transform gunPoint, GameObject bullet)
        {
            _gunPoint = gunPoint;
            _bullet = bullet;
        }

        internal void Fire()
        {
            var clone = GameObject.Instantiate(_bullet, _gunPoint.position, Quaternion.identity);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(_gunPoint.position.x + 20f, _gunPoint.position.y);
        }
    }
}

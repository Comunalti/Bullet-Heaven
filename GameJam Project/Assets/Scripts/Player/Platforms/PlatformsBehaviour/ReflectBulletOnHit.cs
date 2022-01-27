using System;
using UnityEngine;

namespace Player.Platforms.PlatformsBehaviour
{
    [RequireComponent(typeof(Platform))]
    public class ReflectBulletOnHit : MonoBehaviour
    {
        new Rigidbody2D _rigidbody2D;
        private Platform platform;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            platform = GetComponent<Platform>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var bulletScript = other.gameObject.GetComponent<BulletScript>();
            if (bulletScript)
            {
                bulletScript.owner = platform.owner;
                var normal = transform.up;
                var speed = other.attachedRigidbody.velocity;

                var reflected = Vector2.Reflect( speed,normal);

                other.attachedRigidbody.velocity = reflected;
            }
        }
    }
}
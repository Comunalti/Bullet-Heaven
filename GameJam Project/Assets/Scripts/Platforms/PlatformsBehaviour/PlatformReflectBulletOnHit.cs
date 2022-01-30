using System;
using UnityEngine;

namespace Player.Platforms.PlatformsBehaviour
{
    [RequireComponent(typeof(PlatformOwner))]
    public class PlatformReflectBulletOnHit : MonoBehaviour
    {
        new Rigidbody2D _rigidbody2D;
        private PlatformOwner _platformOwner;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _platformOwner = GetComponent<PlatformOwner>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var bulletScript = other.gameObject.GetComponent<BulletScript>();
            if (bulletScript)
            {
                bulletScript.owner = _platformOwner.owner;
                var normal = transform.up;
                var speed = other.attachedRigidbody.velocity;

                var reflected = Vector2.Reflect( speed,normal);

                other.attachedRigidbody.velocity = reflected;
            }
        }
    }
}
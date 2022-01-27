using System;
using UnityEngine;

namespace Player.Platforms.PlatformsBehaviour
{
    public class DestroyBulletOnHit : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var bulletScript = other.gameObject.GetComponent<BulletScript>();
            if (bulletScript && bulletScript.owner != gameObject)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
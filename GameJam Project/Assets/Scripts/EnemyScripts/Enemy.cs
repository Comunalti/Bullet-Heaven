using System;
using UnityEngine;

namespace EnemyScripts{
   [RequireComponent(typeof(Rigidbody2D))]
   public class Enemy : MonoBehaviour{
      [SerializeField] private GameObject _bulletPrefab;
      [SerializeField] private SOEnemyBrainBase brain;
      public Transform _targetTransform;


      private void Start() {
         brain.InitializeBrain(this);
      }

      private void Update() {
         brain.Think(this);
      }

      public void InstantiateBulletPrefab(Vector3 directionVector, float speed, Vector3 startPosition, Quaternion rotation) {
         var bulletInstantiated = Instantiate(_bulletPrefab, startPosition, rotation);
         
         var bulletRigidbody = bulletInstantiated.GetComponent<Rigidbody2D>();
         if (!bulletRigidbody) {
            bulletRigidbody = bulletInstantiated.AddComponent<Rigidbody2D>();
            bulletRigidbody.gravityScale = 0f;
         }

         bulletRigidbody.velocity = directionVector.normalized * speed;
      }
   }
}
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
         enabled = false;
      }

      private void Update() {
         brain.Think(this);
      }

      private void OnBecameVisible() {
         enabled = true;
      }
      
      private void OnBecameInvisible() {
         enabled = false;
         var rgb = GetComponent<Rigidbody2D>();
         rgb.velocity = Vector2.zero;
      }

      public void InstantiateBulletPrefab(Vector3 directionVector, float speed, Vector3 startPosition, Quaternion rotation) {
         var bulletInstantiated = Instantiate(_bulletPrefab, startPosition, rotation);
         var bulletRigidbody = bulletInstantiated.GetComponent<Rigidbody2D>();
        
         bulletRigidbody.velocity = directionVector.normalized * speed;
      }
   }
}
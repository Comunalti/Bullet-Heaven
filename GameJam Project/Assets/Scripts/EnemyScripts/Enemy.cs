using System;
using UnityEngine;

namespace EnemyScripts{
   [RequireComponent(typeof(Rigidbody2D))]
   public class Enemy : MonoBehaviour{
      [SerializeField] private GameObject _bulletPrefab;
      [SerializeField] private SOEnemyBrainBase brain;
      [NonSerialized]  public Transform _targetTransform;
      public Vector3 InitialPositon;
      public Vector3 CurrentTargetPosition;
      public Vector3 TargetPosition;


      private void Start() {
         _targetTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
      }

      private void OnEnable() {
         brain.InitializeBrain(this);
         enabled = true;
      }

      private void OnDisable() {
         brain.StopCorountine(this);
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
         
         //adiciona na memoria da bala para ela não dar dano no proprio inimigo

         var bulletScript = bulletInstantiated.GetComponent<BulletScript>();
         bulletScript.owner = this.gameObject;
      }
   }
}
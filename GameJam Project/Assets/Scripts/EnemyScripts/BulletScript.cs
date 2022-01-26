using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour{
   private void OnCollisionEnter2D(Collision2D other) {
      Destroy(gameObject);
   }
}

using System;
using Entity;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour{
   
   public GameObject owner;
   private void OnBecameInvisible() {
      //Destroy(gameObject);
   }

   private Renderer _renderer;

   private void Start()
   {
      _renderer = GetComponent<Renderer>();
   }

   private void Update()
   {
      CheckOnScreen();
   }

   private void CheckOnScreen()
   {
      if (!_renderer.isVisible)
      {
         Destroy(gameObject);
      }
   }
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (owner == other.gameObject)
      {
         return;
      }
      
      
      var health = other.gameObject.GetComponent<Health>();
      if (health != null)
      {
         health.Remove();
      }
      else
      {
         Destroy(gameObject);
      }
   }
}

using Entity;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour{
   [SerializeField] private float damage = 1;
   
   public GameObject owner;
   private void OnBecameInvisible() {
      //Destroy(gameObject);
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
         health.Remove(damage);
      }
      else
      {
         Destroy(gameObject);
      }
   }
}

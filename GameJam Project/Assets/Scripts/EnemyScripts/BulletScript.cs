using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour{
   private void OnBecameInvisible() {
      Destroy(gameObject);
   }

   private void OnCollisionEnter2D(Collision2D other) {
      if (other.gameObject.tag != "Plataforma") 
         Destroy(gameObject);
      
        
   }
}

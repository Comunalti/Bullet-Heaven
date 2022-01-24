using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour{
    private void OnTriggerEnter2D(Collider2D other) {
            Destroy(gameObject);
    }
}

using Player;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FocusSource : MonoBehaviour
{
    [SerializeField] private int quantity;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var focusSystem = other.gameObject.GetComponent<FocusSystem>();

        if (focusSystem)
        {
            focusSystem.Create(quantity);
            Destroy(gameObject);
        }
    }
}

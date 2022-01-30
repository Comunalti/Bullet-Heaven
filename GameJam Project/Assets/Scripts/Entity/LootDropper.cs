using Unity.Mathematics;
using UnityEngine;

namespace Entity
{
    [RequireComponent(typeof(Health))]
    public class LootDropper : MonoBehaviour
    {
        private Health _health;
        [SerializeField] private GameObject prefab;
        
        private void Start()
        {
            _health = GetComponent<Health>();
            _health.OnDiedEvent += OnDied;
        }

        private void OnDied()
        {
            Instantiate(prefab,transform.position,quaternion.identity);
        }
    }

    // [CreateAssetMenu(menuName = "Create loot configuration")]
    // public class LootConfig : ScriptableObject
    // {
    //     public GameObject prefab;
    // }
}
using DefaultNamespace;
using Entity;
using UnityEngine;

namespace Player{
    [RequireComponent(typeof(Health))]
    public class PlayerDeath : MonoBehaviour{
        private Health _health;
        [SerializeField] private GameObject looseScene;

        private void Awake() {
            _health = GetComponent<Health>();
            _health.OnDiedEvent += OnDied;

            GlobalEvents.LoseGame += uai;
        }

        private void uai() {
            Instantiate(looseScene);
            Time.timeScale = 0;
        }
        
        private void OnDied() {
            GlobalEvents.LoseGame?.Invoke();
        }
    }
}
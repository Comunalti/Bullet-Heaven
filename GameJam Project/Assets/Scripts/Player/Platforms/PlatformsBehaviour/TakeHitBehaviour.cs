using System;
using DefaultNamespace;
using Entity;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Platforms.PlatformsBehaviour
{
    [RequireComponent(typeof(Health))]
    public class TakeHitBehaviour : MonoBehaviour
    {
        private Health _health;
        private Animator _animator;
        private Slider HealthBar;
        private void Start()
        {
            _health = GetComponent<Health>();
            _animator = GetComponent<Animator>();
            HealthBar = gameObject.GetComponentInChildren<Slider>();
            
            _health.OnHealthRemovedEvent += OnTakeDamage;
            _health.OnDiedEvent += OnDied;
        }

        private void OnDestroy()
        {
            _health.OnHealthRemovedEvent -= OnTakeDamage;
            _health.OnDiedEvent -= OnDied;        }

        private void OnDied()
        {
            //Destroy(this);
            Destroy(HealthBar.transform.parent);
            _animator.SetTrigger("Died"); 
            
        }

        public void DestroyAll()
        {
            Destroy(gameObject);
        }

        private void OnTakeDamage(float dmg)
        {
            _animator.SetTrigger("Attacked");
            HealthBar.value = _health.CurrentHealth / _health.MaxHealth;
        }
    }
}
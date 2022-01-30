using System;
using DefaultNamespace;
using Entity;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Platforms.PlatformsBehaviour
{
    [RequireComponent(typeof(Health))]
    public class AnimationTrigger : MonoBehaviour
    {
        private Health _health;
        private Animator _animator;
     
        private void Start()
        {
            _health = GetComponent<Health>();
            _animator = GetComponentInParent<Animator>();
            
            _health.OnHealthRemovedEvent += OnTakeDamage;
            _health.OnDiedEvent += OnDied;
        }

        private void OnDestroy()
        {
            _health.OnHealthRemovedEvent -= OnTakeDamage;
            _health.OnDiedEvent -= OnDied;
        }

        private void OnDied()
        {
            _animator.SetTrigger("Died");
        }
        
        private void OnTakeDamage()
        {
            _animator.SetTrigger("Attacked");
        }
    }
}
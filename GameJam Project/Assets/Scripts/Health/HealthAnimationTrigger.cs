using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

[RequireComponent(typeof(Health),typeof(Animator))]
public class HealthAnimationTrigger : MonoBehaviour
{
    private Animator _animator;
    private Health _health;
    void Start()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();

        _health.OnDiedEvent += OnDied;
        _health.OnHealthAddedEvent += OnHeal;
        _health.OnHealthRemovedEvent += OnDamage;
    }

    private void OnDestroy()
    {
        _health.OnDiedEvent -= OnDied;
        _health.OnHealthAddedEvent -= OnHeal;
        _health.OnHealthRemovedEvent -= OnDamage;
    }

    private void OnHeal()
    {
        _animator.SetTrigger("isHeal");
    }

    private void OnDied()
    {
        _animator.SetTrigger("isDead");
    }
    
    private void OnDamage()
    {
        _animator.SetTrigger("isDamaged");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DestroyOnDeath : MonoBehaviour
{
    private Health _health;
    private float timeBeforeDestroy = 0.5f;
    void Start()
    {
        _health = GetComponent<Health>();
        _health.OnDiedEvent += OnDeath;
    }

    

    private void OnDeath()
    {
        _health.OnDiedEvent -= OnDeath;
        Destroy(gameObject,timeBeforeDestroy);
    }
}

using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;

namespace Entity
{
    public class Health : MonoBehaviour
    {
        public float MaxHealth{ get; private set; }
        public float CurrentHealth{ get; private set; }
        public bool IsDead { get; private set; }
        public event Action OnDiedEvent;
        public event Action OnHealthChangedEvent;

        private void InvokeChange()
        {
            if (CurrentHealth<=0)
            {
                IsDead = true;
            }
            
            OnHealthChangedEvent?.Invoke();
            
            if (IsDead)
            {
                OnDiedEvent?.Invoke();
            }
            
        }
        
        public void Set(float newHealth)
        {
            CurrentHealth = newHealth;
            InvokeChange();
        }

        public void Add(float toAdd)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + toAdd, 0, MaxHealth);
            InvokeChange();
        }

        public void Remove(float toRemove)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - toRemove, 0, MaxHealth);
            InvokeChange();
        }
    }
}
using System;
using UnityEngine;

namespace Entity
{
    public class Health : MonoBehaviour
    { 
        [field : SerializeField]
        public float MaxHealth{ get; private set; }
        [field : SerializeField]
        public float CurrentHealth{ get; private set; }
        //public bool IsDead { get; private set; }
        public event Action OnDiedEvent;
        public event Action<float> OnHealthAddedEvent;
        public event Action<float> OnHealthRemovedEvent;
        
        
        public void Set(float newHealth)
        {
            CurrentHealth = newHealth;

            if (CurrentHealth<=0)
            {
                OnDiedEvent?.Invoke();
            }
        }

        public void Add(float toAdd)
        {
            var initial = CurrentHealth;
            CurrentHealth = Mathf.Clamp(CurrentHealth + toAdd, 0, MaxHealth);
            var delta = CurrentHealth - initial;
            OnHealthAddedEvent?.Invoke(delta);
            if (CurrentHealth<=0)
            {
                OnDiedEvent?.Invoke();
            }
        }

        public void Remove(float toRemove)
        {
            var initial = CurrentHealth;
            CurrentHealth = Mathf.Clamp(CurrentHealth - toRemove, 0, MaxHealth);
            var delta = CurrentHealth - initial; 
            OnHealthRemovedEvent?.Invoke(delta);
            if (CurrentHealth<=0)
            {
                OnDiedEvent?.Invoke();
            }
        }
    }
}
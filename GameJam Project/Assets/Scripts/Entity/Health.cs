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
        public event Action OnHealthAddedEvent;
        public event Action OnHealthRemovedEvent;
        
        
        public void Set(float newHealth)
        {
            CurrentHealth = newHealth;

            if (CurrentHealth<=0)
            {
                OnDiedEvent?.Invoke();
            }
        }

        public void Add()
        {
            var initial = CurrentHealth;
            CurrentHealth = Mathf.Clamp(CurrentHealth + 1, 0, MaxHealth);
            var delta = CurrentHealth - initial;
            if (delta > 0)
            {
                OnHealthAddedEvent?.Invoke();
                if (CurrentHealth<=0)
                {
                    OnDiedEvent?.Invoke();
                }
            }
        }

        public void Remove()
        {
            var initial = CurrentHealth;
            CurrentHealth = Mathf.Clamp(CurrentHealth - 1, 0, MaxHealth);
            var delta = CurrentHealth - initial; 
            OnHealthRemovedEvent?.Invoke();
            if (CurrentHealth<=0)
            {
                OnDiedEvent?.Invoke();
            }
        }
    }
}
using System;
using UnityEngine;

namespace Player{
    public class FocusSystem : MonoBehaviour{
        [SerializeField] private float _currentFocus; //esse serialize field é só pra facilitar o debug
        [SerializeField] private float gainFocusPerSecond;
        public float MaximumFocus;

        public event Action<int> IntegerFocusAddedEvent;
        public event Action<int> IntegerFocusRemovedEvent;
        
        private void Awake() {
            _currentFocus = MaximumFocus;
        }

        private void Update() {
            AddFocus(gainFocusPerSecond * Time.deltaTime);
        }

        public void AddFocus(float delta) {
            var beforeFocus = Mathf.FloorToInt(_currentFocus);
            
            _currentFocus = Mathf.Clamp(_currentFocus + delta, 0, MaximumFocus);
            
            var afterfocus = Mathf.FloorToInt(_currentFocus);


            var focusRealDelta = afterfocus - beforeFocus;
            
            if(focusRealDelta <= 0) return;
            
            IntegerFocusAddedEvent?.Invoke(focusRealDelta);
        }
        
        public void RemoveFocus(float delta) {
            var beforeFocus = Mathf.FloorToInt(_currentFocus);
            
            _currentFocus = Mathf.Clamp(_currentFocus - delta, 0, MaximumFocus);
            
            var afterfocus = Mathf.FloorToInt(_currentFocus);
            
            var focusRealDelta = beforeFocus - afterfocus;
            if(focusRealDelta <= 0) return;
            
            IntegerFocusRemovedEvent?.Invoke(focusRealDelta);
        }
        
        
        public float CurrentFocus => _currentFocus;

        
    }
}
using System;
using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [CreateAssetMenu(fileName = "Input reader", menuName = "Input reader")]
    public class InputReader : ScriptableObject, PlayerControls.IMovementActions
    {
        public event Action<float> HorizontalChangedEvent;
        public event Action<bool> JumpChangedEvent;
        
        private void Initialize()
        {
        
            var playerControls = new PlayerControls();
            var movementActions = new PlayerControls.MovementActions(playerControls);
            movementActions.SetCallbacks(this);
            movementActions.Enable();
        }

        private void Awake()
        {
            Initialize();
        
        }

        private void Reset()
        {
            Initialize();
        }

        public void OnEnable()
        {
            Initialize();
        }

        private void OnDisable()
        {
            //_movementActions.Disable();
     
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            HorizontalChangedEvent?.Invoke(context.ReadValue<float>());
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            JumpChangedEvent?.Invoke(context.ReadValueAsButton());
        }
    }
}
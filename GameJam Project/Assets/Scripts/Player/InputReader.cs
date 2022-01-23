using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [CreateAssetMenu(fileName = "Input reader", menuName = "Input reader")]
    public class InputReader : ScriptableObject, PlayerControls.IMovementActions, PlayerControls.IMouseActions
    {
        public event Action<float> HorizontalChangedEvent;
        public event Action<bool> JumpChangedEvent;

        public event Action<Vector2> MousePositionChangedEvent;
        public event Action<bool> MouseRightClickChangedEvent;
        public event Action<bool> MouseLeftClickChangedEvent;
        
        
        private void Initialize()
        {
        
            var playerControls = new PlayerControls();
            var movementActions = new PlayerControls.MovementActions(playerControls);
            var mouseActions = new PlayerControls.MouseActions(playerControls);
            
            movementActions.SetCallbacks(this);
            mouseActions.SetCallbacks(this);
            
            movementActions.Enable();
            mouseActions.Enable();
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

        public void OnMouseRightClick(InputAction.CallbackContext context)
        {
            Debug.Log(context.ReadValueAsButton());
            //MouseRightClickChangedEvent?.Invoke(context.ReadValueAsButton());
        }

        public void OnMouseLeftClick(InputAction.CallbackContext context)
        {
            Debug.Log(context.ReadValueAsButton());
        }

        public void OnMouseMove(InputAction.CallbackContext context)
        {
            Debug.Log(context.ReadValue<Vector2>());
        }

        public void OnMouseScroll(InputAction.CallbackContext context)
        {
            Debug.Log(context.ReadValue<float>());
        }
    }
}
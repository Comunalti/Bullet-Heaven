using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    //[CreateAssetMenu(fileName = "Input reader", menuName = "Input reader")]
    public class InputReader : MonoBehaviour, PlayerControls.IMovementActions, PlayerControls.IMouseActions, PlayerControls.IPauseActions
    {
        [SerializeField] private GameObject escCanvasPrefab;
        public bool isPaused;
        private GameObject _escCanvas;
        public event Action<float> HorizontalChangedEvent;
        public event Action<bool> JumpChangedEvent;

        public event Action<Vector2> MousePositionChangedEvent;
        public event Action<bool> MouseRightClickChangedEvent;
        public event Action<bool> MouseLeftClickChangedEvent;
        public event Action<Vector2> MouseDeltaChangedEvent;
        

        [SerializeField] private bool active;

        private void Initialize()
        {
            if (active)
            {
                return;
            }

            active = true;
            
            var playerControls = new PlayerControls();
            var movementActions = new PlayerControls.MovementActions(playerControls);
            var mouseActions = new PlayerControls.MouseActions(playerControls);
            var pauseActions = new PlayerControls.PauseActions(playerControls);

            
            movementActions.SetCallbacks(this);
            mouseActions.SetCallbacks(this);
            pauseActions.SetCallbacks(this);

            
            movementActions.Enable();
            mouseActions.Enable();
            pauseActions.Enable();

        }

        private void Awake()
        {
            Initialize();
        
        }

        

        public void OnMove(InputAction.CallbackContext context)
        {
            HorizontalChangedEvent?.Invoke(context.ReadValue<float>());
        }
        
        
        

        public void OnJump(InputAction.CallbackContext context)
        {
            //Debug.Log(context.phase);
            if (context.phase == InputActionPhase.Started ||context.phase == InputActionPhase.Canceled)
                JumpChangedEvent?.Invoke(context.ReadValueAsButton());
        }

        public void OnMouseRightClick(InputAction.CallbackContext context){
           // Debug.Log(context.ReadValueAsButton());
           if (context.phase == InputActionPhase.Started ||context.phase == InputActionPhase.Canceled)
               MouseRightClickChangedEvent?.Invoke(context.ReadValueAsButton());
        }

        public void OnMouseLeftClick(InputAction.CallbackContext context)
        {
            //Debug.Log(context.ReadValueAsButton());
            if (context.phase == InputActionPhase.Started ||context.phase == InputActionPhase.Canceled)
                MouseLeftClickChangedEvent?.Invoke(context.ReadValueAsButton());
        }

        public void OnMouseMove(InputAction.CallbackContext context)
        {
            // Debug.Log(context.ReadValue<Vector2>());
            //if (context.phase == InputActionPhase.Started ||context.phase == InputActionPhase.Canceled)
                MousePositionChangedEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnMouseScroll(InputAction.CallbackContext context)
        {
            //Debug.Log(context.ReadValue<float>());
            //if (context.phase == InputActionPhase.Started ||context.phase == InputActionPhase.Canceled)

        }

        public void OnMouseDelta(InputAction.CallbackContext context)
        {
            //Debug.Log(context.ReadValue<Vector2>());
            //Debug.Log(context.phase);
            // if (context.phase == InputActionPhase.Performed)
            // {
            //     Debug.Log(context.ReadValue<Vector2>());
            // }
            if (context.phase == InputActionPhase.Started ||context.phase == InputActionPhase.Canceled)
                MouseDeltaChangedEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnEsc(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started)
                return;

            if (escCanvasPrefab == null)
            {
                Debug.LogError("ta faltando a porra do prefab do menu de pause em algum lugar aaaaaa");
                return;
            }

            if (_escCanvas == null)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }

        public void UnPause()
        {
            Destroy(_escCanvas);

            isPaused = false;
            Time.timeScale = 1;
        }

        public void Pause()
        {
            _escCanvas = Instantiate(escCanvasPrefab);

            isPaused = true;
            Time.timeScale = 0;
        }
    }
}
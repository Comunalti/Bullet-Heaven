using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [CreateAssetMenu(fileName = "Input reader", menuName = "Input reader")]
    public class InputReader : ScriptableObject, PlayerControls.IMovementActions
    {
        [SerializeField] private GameObject prefab;

        private void Initialize()
        {
        
            var playerControls = new PlayerControls();
            var _movementActions = new PlayerControls.MovementActions(playerControls);
            _movementActions.SetCallbacks(this);
            _movementActions.Enable();
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
            Debug.Log(context.ReadValue<float>());
        
        
            GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            Debug.Log(context.ReadValue<float>());
        }
    }
}
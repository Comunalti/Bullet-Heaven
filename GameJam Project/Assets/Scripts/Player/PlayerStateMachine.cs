using System;
using UnityEngine;

namespace Player
{
    public class PlayerStateMachine : MonoBehaviour
    {
        [SerializeField] private PlayerState currentState;

        [SerializeField] private Action StateChangedEvent;

        // Start is called before the first frame update
        void Start()
        {
            SetState(currentState);
        }

        void Update()
        {
            currentState.UpdatePlayer(this);
        }

        public void SetState(PlayerState newState)
        {
            if (newState == currentState)
                return;
            currentState?.LeaveState();
            currentState = newState;
            newState?.EnterState();
            StateChangedEvent?.Invoke();
        }
    }
}
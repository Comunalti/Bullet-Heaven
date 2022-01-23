using UnityEngine;

namespace Player
{
    public abstract class PlayerState : ScriptableObject
    {
        public virtual void UpdatePlayer(StateHandler stateHandler)
        {
            throw new System.NotImplementedException();
        }

        public virtual void LeaveState()
        {
            throw new System.NotImplementedException();
        }

        public virtual void EnterState()
        {
            throw new System.NotImplementedException();
        }
    }
}
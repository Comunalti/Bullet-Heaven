using UnityEngine;

namespace Boss{
    public class BossStateMachineManager : MonoBehaviour{
        private BaseState _currentState;
        private BaseState[] _atacksArray;
        private IdleState idleState;
        [SerializeField] private float idleStateCooldownInSeconds;
        [SerializeField] private DogController dogController;

        
        private void Awake() {
            _atacksArray = new BaseState[]{new WaveAttack(this), new DogsAttack(this, dogController), new MultiLasersAttack(this)};
            idleState = new IdleState(this, idleStateCooldownInSeconds);
            _currentState = idleState;
        }

        private void Start() {
            _currentState.EnterState();
        }

        private void Update() {
            _currentState.ExecuteState();
        }

        public void ChangeState(BaseState nextState) {
            _currentState.ExitState();
            _currentState = nextState;
            _currentState.EnterState();
        }
        
        public BaseState[] AtacksArray => _atacksArray;
        public BaseState CurrentState => _currentState;
        public IdleState IdleState => idleState;

    }
}
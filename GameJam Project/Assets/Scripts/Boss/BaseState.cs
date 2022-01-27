namespace Boss{
    public abstract class BaseState{

        protected BossStateMachineManager _stateMachineManager;
        public abstract void EnterState();
        public abstract void ExecuteState();
        public abstract void ExitState();

        public BaseState(BossStateMachineManager stateMachineManager) {
            _stateMachineManager = stateMachineManager;
        }
        
    }
}
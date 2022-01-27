using UnityEngine;

namespace Boss{
    public class DogsAttack : BaseState{
        private DogController _dogController;


        public override void EnterState() {
            Debug.Log("Início do Dog Attack");
        }

        public override void ExecuteState() {
            _dogController.InitializeAttack();
        }

        public override void ExitState() {
            Debug.Log("Fim do Dog Attack");
        }
        
        public DogsAttack(BossStateMachineManager stateMachineManager, DogController dogController) : base(stateMachineManager) {
            _dogController = dogController;
        }
    }
}
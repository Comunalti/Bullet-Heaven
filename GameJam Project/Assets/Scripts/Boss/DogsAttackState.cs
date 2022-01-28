using UnityEngine;

namespace Boss{
    public class DogsAttackState : BaseState{
        private DogController _dogController;


        public override void EnterState() {
            Debug.Log("Início do Dog Attack");
            _dogController.EndState += _bossStateMachineManager.ChangeToIdleState;
            _dogController.StartAttack();
        }

        public override void ExecuteState() {
            _dogController.UpdateAttack();
        }

        public override void ExitState() {
            Debug.Log("Fim do Dog Attack");
            _dogController.EndState -= _bossStateMachineManager.ChangeToIdleState;
        }


        
        public DogsAttackState(BossStateMachineManager bossStateMachineManager, DogController dogController, GameObject bulletPrefab, float bulletSpeed) : base(bossStateMachineManager, bulletPrefab, bulletSpeed) {
            _dogController = dogController;
        }
    }
}
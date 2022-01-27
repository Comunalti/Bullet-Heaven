
using UnityEngine;

namespace Boss{
    public class WaveAttack : BaseState{


        public override void EnterState() {
            Debug.Log("Início do Wave Attack");
        }

        public override void ExecuteState() {
        }

        public override void ExitState() {
            Debug.Log("Fim do Wave Attack");
        }

        public WaveAttack(BossStateMachineManager stateMachineManager) : base(stateMachineManager) {
        }
    }
}
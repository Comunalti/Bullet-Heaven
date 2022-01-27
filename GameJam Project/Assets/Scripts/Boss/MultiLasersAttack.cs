using UnityEngine;

namespace Boss{
    public class MultiLasersAttack : BaseState{


        public override void EnterState() {
            Debug.Log("Início do Ataque de lasers");
        }

        public override void ExecuteState() {
            
        }

        public override void ExitState() {
            Debug.Log("Fim do Ataque de lasers");
        }
        
        public MultiLasersAttack(BossStateMachineManager stateMachineManager) : base(stateMachineManager) {
        }
    }
}
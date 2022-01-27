using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace Boss{
    [Serializable]
    public class IdleState : BaseState{
        private BaseState[] _statesArray;
        private BaseState _lastState;
        private float _idleStateCooldownInSeconds;
        
        public override void EnterState() {
            _stateMachineManager.StartCoroutine(IdleStateCoroutine(_idleStateCooldownInSeconds));
            Debug.Log("Início do Idle");
        }

        public override void ExecuteState() {
            
        }

        public override void ExitState() {
            Debug.Log("Fim do Idle");
        }

        private IEnumerator IdleStateCoroutine(float cooldownInSeconds) {
            yield return new WaitForSeconds(cooldownInSeconds);
            
            var nextState = PickARandomObjectFromArray(_statesArray);
            while (nextState == _lastState) {
                nextState = PickARandomObjectFromArray(_statesArray);
            }

            _lastState = nextState;
            
            _stateMachineManager.ChangeState(nextState);
        }
        
        private T PickARandomObjectFromArray<T>(T[] array) {
            var rdn = new Random();

            var randomNumber = rdn.Next(array.Length);

            return array[randomNumber];
        }
        
        public IdleState(BossStateMachineManager stateMachineManager, float idleStateCooldownInSeconds) : base(stateMachineManager) {
            _statesArray = _stateMachineManager.AtacksArray;
            _idleStateCooldownInSeconds = idleStateCooldownInSeconds;
        }
        
    }
}
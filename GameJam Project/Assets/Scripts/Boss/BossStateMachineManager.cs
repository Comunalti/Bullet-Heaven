﻿using UnityEngine;

namespace Boss{
    public class BossStateMachineManager : MonoBehaviour{
        private BaseState _currentState;
        private BaseState[] _atacksArray;
        private IdleState idleState;
        [SerializeField] private float idleStateCooldownInSeconds;
        [SerializeField] private DogController dogController;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private int numberOfCirclesInLaserAttack = 10;
        [SerializeField] private int numberOfShotsInACircleInLaserAttack = 40;
        private Animator _animator;

        
        private void Awake() {
            _animator = GetComponent<Animator>();
            _atacksArray = new BaseState[]{
                
                new WaveAttack(this, bulletPrefab, bulletSpeed, numberOfCirclesInLaserAttack, numberOfShotsInACircleInLaserAttack, _animator),
                new DogsAttackState(this, dogController, bulletPrefab, bulletSpeed, _animator),
                new MultiLasersAttack(this, bulletPrefab, bulletSpeed, numberOfCirclesInLaserAttack, numberOfShotsInACircleInLaserAttack, _animator)
                
            };
            idleState = new IdleState(this, idleStateCooldownInSeconds, bulletPrefab, bulletSpeed, _animator);
            _currentState = idleState;
        }

        private void Start() {
            _currentState.EnterState();
        }

        private void Update() {
            _currentState.ExecuteState();
        }

        public void ChangeToIdleState() {
            ChangeState(IdleState);
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
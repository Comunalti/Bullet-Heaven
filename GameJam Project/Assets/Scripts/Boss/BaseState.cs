using UnityEngine;

namespace Boss{
    public abstract class BaseState{

        protected BossStateMachineManager _bossStateMachineManager;
        protected GameObject _bulletPrefab;
        protected float _bulletSpeed;
        protected Animator _animator;
        
        public abstract void EnterState();
        public abstract void ExecuteState();
        public abstract void ExitState();

        public BaseState(BossStateMachineManager bossStateMachineManager, GameObject bulletPrefab, float bulletSpeed, Animator animator) {
            _bossStateMachineManager = bossStateMachineManager;
            _bulletPrefab = bulletPrefab;
            _bulletSpeed = bulletSpeed;
            _animator = animator;
        }
        
    }
}
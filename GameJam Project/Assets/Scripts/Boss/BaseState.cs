using UnityEngine;

namespace Boss{
    public abstract class BaseState{

        protected BossStateMachineManager _bossStateMachineManager;
        protected GameObject _bulletPrefab;
        protected float _bulletSpeed;
        public abstract void EnterState();
        public abstract void ExecuteState();
        public abstract void ExitState();

        public BaseState(BossStateMachineManager bossStateMachineManager, GameObject bulletPrefab, float bulletSpeed) {
            _bossStateMachineManager = bossStateMachineManager;
            _bulletPrefab = bulletPrefab;
            _bulletSpeed = bulletSpeed;
        }
        
    }
}
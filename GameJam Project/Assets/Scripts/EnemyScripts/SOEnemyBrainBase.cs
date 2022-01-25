using UnityEngine;

namespace EnemyScripts{
    public abstract class SOEnemyBrainBase : SOBrain{
        [SerializeField] protected float shotsCooldown;
        [SerializeField] protected float bulletSpeed;
        [SerializeField] protected float enemySpeed;
        [SerializeField] protected float bulletsOffset;

        protected abstract void AimAndShot(Enemy enemy);
        protected abstract void MoveEnemyHorizontally(Enemy enemy, Vector2 direction);
    }
}
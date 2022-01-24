using System.Collections;
using UnityEngine;

namespace EnemyScripts{
    [CreateAssetMenu(menuName = "Brains Scriptable Objects/EnemyBrain")]
    public class FlyingEnemyBrain : Brain{
        [SerializeField] private float _shotsCooldown;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _enemySpeed;
        [SerializeField] private LayerMask _wallLayer;
        [SerializeField] private float _raycastOffset = 0.6f;
        [SerializeField] private float _bulletsOffset;

        public override void InitializeBrain(MonoBehaviour monoBehaviour) {
            var enemy = (Enemy) monoBehaviour;
            enemy.StartCoroutine(StartShotAfterCooldown(_shotsCooldown, enemy));
        }
        
        public override void Think(MonoBehaviour monoBehaviour) {
            var enemy = (Enemy) monoBehaviour;
            MoveEnemyHorizontally(enemy);

        }

        private void AimAndShot(Enemy enemy) {
            var direction = (enemy._targetTransform.position - enemy.transform.position).normalized;
            
            
            enemy.InstantiateBulletPrefab(direction, _bulletSpeed, enemy.transform.position, enemy.transform.rotation);
            enemy.InstantiateBulletPrefab(direction, _bulletSpeed, enemy.transform.position + Vector3.down * _bulletsOffset, enemy.transform.rotation);
            enemy.InstantiateBulletPrefab(direction, _bulletSpeed, enemy.transform.position + Vector3.down * _bulletsOffset * 2, enemy.transform.rotation);
        }

        private void MoveEnemyHorizontally(Enemy enemy) {
            var enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
            
            enemyRigidbody.velocity = Vector2.right * _enemySpeed;

            if (Physics2D.Raycast(enemy.transform.position, enemyRigidbody.velocity.normalized, _raycastOffset, _wallLayer)) {
                enemyRigidbody.velocity *= -1;
                _enemySpeed *= -1;
            }
        }

        private IEnumerator StartShotAfterCooldown(float seconds, Enemy enemy) {
            while(true) {
                yield return new WaitForSeconds(seconds);
                AimAndShot(enemy);
            }
        }

    }
}
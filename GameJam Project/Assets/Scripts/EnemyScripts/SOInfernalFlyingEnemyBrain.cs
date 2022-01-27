using System.Collections;
using UnityEngine;

namespace EnemyScripts{
    [CreateAssetMenu(menuName = "Brains Scriptable Objects/Infernal Flying Enemy Brain")]
    public class SOInfernalFlyingEnemyBrain : SOEnemyBrainBase{
        [SerializeField] private LayerMask wallLayer;
        [SerializeField] private float raycastOffset = 0.6f;

        public override void InitializeBrain(MonoBehaviour monoBehaviour) {
            var enemy = (Enemy) monoBehaviour;
            enemy.StartCoroutine(StartShotAfterCooldownCoroutine(enemy));
        }
        
        public override void Think(MonoBehaviour monoBehaviour) {
            var enemy = (Enemy) monoBehaviour;
            MoveEnemyHorizontally(enemy, Vector2.right);

        }

        protected override void AimAndShot(Enemy enemy) {
            var direction = (enemy._targetTransform.position - enemy.transform.position).normalized;

            var rotation = Quaternion.Euler(Vector3.forward * -90);
                            
            enemy.InstantiateBulletPrefab(direction, bulletSpeed, enemy.transform.position, rotation);
            enemy.InstantiateBulletPrefab(direction, bulletSpeed, enemy.transform.position + Vector3.down * bulletsOffset, rotation);
            enemy.InstantiateBulletPrefab(direction, bulletSpeed, enemy.transform.position + Vector3.down * bulletsOffset * 2, rotation);
        }

        protected override void MoveEnemyHorizontally(Enemy enemy, Vector2 initialDirection) {
            var enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
            
            enemyRigidbody.velocity = initialDirection * enemySpeed;

            if (Physics2D.Raycast(enemy.transform.position, enemyRigidbody.velocity.normalized,raycastOffset,wallLayer)) {
                enemyRigidbody.velocity *= -1;
                enemySpeed *= -1;
            }
        }

        private IEnumerator StartShotAfterCooldownCoroutine(Enemy enemy) {
            while(true) {
                yield return new WaitForSeconds(shotsCooldown);
                AimAndShot(enemy);
            }
        }

    }
}
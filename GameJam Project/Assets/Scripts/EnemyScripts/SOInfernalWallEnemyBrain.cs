using System.Collections;
using UnityEngine;

namespace EnemyScripts{
    [CreateAssetMenu(menuName = "Brains Scriptable Objects/Infernal Wall Enemy Brain")]
    public class SOInfernalWallEnemyBrain : SOEnemyBrainBase{
        [SerializeField] private float enemyOffsetPosition;
        private Vector3 _initialPosition;
        private Vector3 _currentTargetPosition;
        private Vector3 _targetPostion;
        
        
        public override void InitializeBrain(MonoBehaviour monoBehaviour) {
            var enemy = (Enemy)monoBehaviour;

            _initialPosition = enemy.transform.position;
            _targetPostion = enemy.transform.position + (Vector3.right * enemyOffsetPosition);

            monoBehaviour.StartCoroutine(WalkAndShotCoroutine(enemy));
        }

        public override void Think(MonoBehaviour monobehaviour) {
            var enemy = (Enemy)monobehaviour;
            MoveEnemyHorizontally(enemy, _currentTargetPosition);
        }


        private IEnumerator WalkAndShotCoroutine(Enemy enemy) {
            while(true) {
                _currentTargetPosition = _targetPostion;
                
                yield return new WaitUntil(() => _currentTargetPosition == enemy.transform.position);
                yield return new WaitForSeconds(0.5f);

                AimAndShot(enemy);

                yield return new WaitForSeconds(3);

                _currentTargetPosition = _initialPosition;

                yield return new WaitUntil(() => _currentTargetPosition == enemy.transform.position);
                yield return new WaitForSeconds(shotsCooldown);
            }
        }
        
        
        protected override void AimAndShot(Enemy enemy) {
            var direction = (enemy._targetTransform.position - enemy.transform.position).normalized;
            
            
            enemy.InstantiateBulletPrefab(direction, bulletSpeed, enemy.transform.position, enemy.transform.rotation);
            enemy.InstantiateBulletPrefab(direction, bulletSpeed, enemy.transform.position + Vector3.right * bulletsOffset, enemy.transform.rotation);
            enemy.InstantiateBulletPrefab(direction, bulletSpeed, enemy.transform.position - Vector3.right * bulletsOffset, enemy.transform.rotation);
        }

        protected override void MoveEnemyHorizontally(Enemy enemy, Vector2 targetPosition) {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPosition, enemySpeed * Time.deltaTime);
        }
    }
}
using System.Collections;
using UnityEngine;

namespace EnemyScripts{
    [CreateAssetMenu(menuName = "Brains Scriptable Objects/Infernal Wall Enemy Brain")]
    public class SOInfernalWallEnemyBrain : SOEnemyBrainBase{
        [SerializeField] private float enemyOffsetPosition;
        
        
        public override void InitializeBrain(MonoBehaviour monoBehaviour) {
            var enemy = (Enemy)monoBehaviour;

            enemy.InitialPositon = enemy.transform.position;
            enemy.TargetPosition = enemy.transform.position + (Vector3.right * enemyOffsetPosition);

            monoBehaviour.StartCoroutine(WalkAndShotCoroutine(enemy));
        }

        public override void Think(MonoBehaviour monobehaviour) {
            var enemy = (Enemy)monobehaviour;
            MoveEnemyHorizontally(enemy, enemy.CurrentTargetPosition);
        }


        private IEnumerator WalkAndShotCoroutine(Enemy enemy) {
            while(true) {
                enemy.CurrentTargetPosition = enemy.TargetPosition;
                
                yield return new WaitUntil(() => enemy.CurrentTargetPosition == enemy.transform.position);
                yield return new WaitForSeconds(0.5f);

                AimAndShot(enemy);

                yield return new WaitForSeconds(shotsCooldown);

                enemy.CurrentTargetPosition = enemy.InitialPositon;

                yield return new WaitUntil(() => enemy.CurrentTargetPosition == enemy.transform.position);
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
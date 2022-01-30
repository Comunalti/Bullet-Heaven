using System.Collections;
using UnityEngine;

namespace Boss{
    public class MultiLasersAttack : BaseState{
        private int _numberOfShotsInACircle;
        private int _numberOfCircles;

        public override void EnterState() {
            Debug.Log("Início do Ataque de lasers");
            _bossStateMachineManager.StartCoroutine(ShotInCircleCoroutine());
        }

        public override void ExecuteState() {
            
        }

        public override void ExitState() {
            Debug.Log("Fim do Ataque de lasers");
        }


        private IEnumerator ShotInCircleCoroutine() {
            var bossPosition = _bossStateMachineManager.transform.position;
            
            for(var i = 0; i<_numberOfCircles; i++){ //quantas layers de tiro o circulo terá
                yield return new WaitForSeconds(0.5f);
                for (var j = 0; j < 360; j += Mathf.RoundToInt(360 / _numberOfShotsInACircle)) { //quantos tiros o circulo será composto
                    var angleInRadians = Mathf.Deg2Rad * j;
                    var xPosition = bossPosition.x + 4 * Mathf.Cos(angleInRadians);
                    var yPosition = bossPosition.y + 4 * Mathf.Sin(angleInRadians);

                    var vectorPosition = new Vector3(xPosition, yPosition, bossPosition.z);
                    var velocityDirection = (vectorPosition - bossPosition);
                    InstantiateBullet(vectorPosition, velocityDirection);
                }
            }

            yield return new WaitForSeconds(2f);
            _bossStateMachineManager.ChangeToIdleState();
        }
        
        private void InstantiateBullet(Vector3 position, Vector3 direction) {
            var bullet = GameObject.Instantiate(_bulletPrefab, position, Quaternion.Euler(Vector3.forward * -90f));

            var bulletRgb = bullet.GetComponent<Rigidbody2D>();
            bulletRgb.velocity = direction.normalized * _bulletSpeed;
        }
        
        
        public MultiLasersAttack(BossStateMachineManager bossStateMachineManager, GameObject bulletPrefab, float bulletSpeed, int numberOfCircles, int numberOfShotsInACircle, Animator animator) : base(bossStateMachineManager, bulletPrefab, bulletSpeed, animator) {
            _numberOfCircles = numberOfCircles;
            _numberOfShotsInACircle = numberOfShotsInACircle;
        }
    }
}
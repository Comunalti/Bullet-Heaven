
using System.Collections;
using UnityEngine;

namespace Boss{
    public class WaveAttack : BaseState{
        private int _numberOfShotsInACircle;
        private int _numberOfCircles;

        public override void EnterState() {
            Debug.Log("Início do Wave Attack");
            _bossStateMachineManager.StartCoroutine(ShotInCircleCoroutine());
        }

        public override void ExecuteState() {
        }

        public override void ExitState() {
            Debug.Log("Fim do Wave Attack");
        }

        private IEnumerator ShotInCircleCoroutine() {
            var bossPosition = _bossStateMachineManager.transform.position;

            var random = new System.Random();
            
            for(var i = 0; i<_numberOfCircles; i++) {
                //quantas layers de tiro o circulo terá
                yield return new WaitForSeconds(1);

                var leftOrRight = random.Next(0, 2);
                
                if(leftOrRight == 0)
                    ShotInWaveRight(bossPosition);
                else
                    ShotInWaveLeft(bossPosition);
            }

            yield return new WaitForSeconds(2f);
            _bossStateMachineManager.ChangeToIdleState();
        }

        private void ShotInWaveRight(Vector3 bossPosition) {
            for (var j = 180; j < 270; j += Mathf.RoundToInt(180 / _numberOfShotsInACircle)) {
                //quantos tiros o circulo será composto
                var angleInRadians = Mathf.Deg2Rad * j;
                var xPosition = bossPosition.x + 4 * Mathf.Cos(angleInRadians);
                var yPosition = bossPosition.y + 4 * Mathf.Sin(angleInRadians);

                var vectorPosition = new Vector3(xPosition, yPosition, bossPosition.z);
                var velocityDirection = (vectorPosition - bossPosition);
                InstantiateBullet(vectorPosition, velocityDirection);
            }
        }

        private void ShotInWaveLeft(Vector3 bossPosition) {
            for (var j = 270; j < 360; j += Mathf.RoundToInt(180 / _numberOfShotsInACircle)) {
                //quantos tiros o circulo será composto
                var angleInRadians = Mathf.Deg2Rad * j;
                var xPosition = bossPosition.x + 4 * Mathf.Cos(angleInRadians);
                var yPosition = bossPosition.y + 4 * Mathf.Sin(angleInRadians);

                var vectorPosition = new Vector3(xPosition, yPosition, bossPosition.z);
                var velocityDirection = (vectorPosition - bossPosition);
                InstantiateBullet(vectorPosition, velocityDirection);
            }
        }

        private void InstantiateBullet(Vector3 position, Vector3 direction) {
            var bullet = GameObject.Instantiate(_bulletPrefab, position, Quaternion.Euler(Vector3.forward * -90f));

            var bulletRgb = bullet.GetComponent<Rigidbody2D>();
            bulletRgb.velocity = direction.normalized * _bulletSpeed;
        }
        
        public WaveAttack(BossStateMachineManager bossStateMachineManager, GameObject bulletPrefab, float bulletSpeed, int numberOfCircles, int numberOfShotsInACircle) : base(bossStateMachineManager, bulletPrefab, bulletSpeed) {
            _numberOfCircles = numberOfCircles;
            _numberOfShotsInACircle = numberOfShotsInACircle;
        }
    }
}
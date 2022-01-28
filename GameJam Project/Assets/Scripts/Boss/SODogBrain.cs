using System.Collections;
using UnityEngine;

namespace Boss{
    [CreateAssetMenu(menuName = "Brains Scriptable Objects/Boss' Dog Brain")]
    public class SODogBrain : ScriptableObject{
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float dogSpeed;
        [SerializeField] private float secondsUntilShot;
        [SerializeField] private int numberOfShots;


        public void StartBrain(DogController dogScript) {
            dogScript.InitialPosition = dogScript.transform.position;
            ChangeDogScriptPositionRandomly(dogScript);
            dogScript.StartCoroutine( MoveAndShotCoroutine(dogScript));
        }
        
        public void UpdateBrain(DogController dogScript, GameObject dogGameobj) {
            dogScript.StartCoroutine(MoveDogToAPositionCoroutine(dogScript.NextPosition, dogGameobj));
        }


        private IEnumerator MoveAndShotCoroutine(DogController dogScript) {
            yield return new WaitUntil(() => dogScript.transform.position == dogScript.NextPosition);
            yield return new WaitForSeconds(secondsUntilShot);

            for (int i = 0; i < numberOfShots; i++) {
                ShotThreeBullets(dogScript);
                yield return new WaitForSeconds(0.3f); //esse valor fixo é o offset horizontal entre as balas, não achei que havia necessidade de deixar serializado
            }

            yield return new WaitForSeconds(1);
            dogScript.NextPosition = dogScript.InitialPosition;
            yield return new WaitUntil(() => dogScript.transform.position == dogScript.InitialPosition);
            
            dogScript.EndState?.Invoke();
        }

        private void ShotThreeBullets(DogController dogScript) {
            InstantiateBullet(dogScript.transform.position);
            InstantiateBullet(dogScript.transform.position + Vector3.up * 0.8f); //esse valor fixo é o offset vertical entre as balas
            InstantiateBullet(dogScript.transform.position + Vector3.down * 0.8f);
        }


        
        private void InstantiateBullet(Vector3 position) {
            var bullet = Instantiate(bulletPrefab, position, Quaternion.identity);

            var bulletRgb = bullet.GetComponent<Rigidbody2D>();
            bulletRgb.velocity = Vector2.right * bulletSpeed;
        }
        
        private void ChangeDogScriptPositionRandomly(DogController dogScript) {
            var random = new System.Random();
            var position = dogScript.transform.position;
            
            
            dogScript.NextPosition = new Vector3(dogScript.XPositionToShot.position.x, random.Next(3,11), position.z);
        }
        
        private IEnumerator MoveDogToAPositionCoroutine(Vector3 position, GameObject dogGameObj) {
            yield return null;
            dogGameObj.transform.position = Vector3.MoveTowards(dogGameObj.transform.position, position, dogSpeed * Time.deltaTime);
        }
    }
}
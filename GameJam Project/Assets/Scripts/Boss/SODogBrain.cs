using System.Collections;
using UnityEngine;

namespace Boss{
    [CreateAssetMenu(menuName = "Brains Scriptable Objects/Boss' Dog Brain")]
    public class SODogBrain : ScriptableObject{
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float dogSpeed;
        

        public void InitializeBrain(DogController dogScript, GameObject dogGameobj) {
            
        }

        private IEnumerator MoveAndDoSomeShit(MonoBehaviour obj, GameObject dogGameobj, Vector3 position) {
            obj.StartCoroutine(
                MoveDogToAPositionCoroutine(position, dogGameobj));
            yield return new WaitUntil(() =>
                dogGameobj.transform.position == position);
            Debug.Log("Esse debug é depois que ele parou de se mover?");
        }
        
        
        private IEnumerator MoveDogToAPositionCoroutine(Vector3 position, GameObject dogGameObj) {
            yield return null;
            
            dogGameObj.transform.position = Vector3.MoveTowards(dogGameObj.transform.position, position, dogSpeed * Time.deltaTime);
        }
    }
}
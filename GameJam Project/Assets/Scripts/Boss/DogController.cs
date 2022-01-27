using Boss;
using UnityEngine;

public class DogController : MonoBehaviour{
    [SerializeField] private SODogBrain _brain;

    public void InitializeAttack() {
        _brain.InitializeBrain(this, gameObject);
    }

}

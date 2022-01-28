using System;
using Boss;
using UnityEngine;

public class DogController : MonoBehaviour{
    [SerializeField] private SODogBrain _brain;
    [NonSerialized] public Vector3 NextPosition;
    [NonSerialized] public Vector3 InitialPosition;
    public Transform PlayerTransform;
    public Transform XPositionToShot;
    
    public Action EndState;

    public void StartAttack() {
        XPositionToShot.parent = null;

        _brain.StartBrain(this);
    }
    
    public void UpdateAttack() {
        _brain.UpdateBrain(this, gameObject);
    }
    
}

using UnityEngine;

namespace Player{
    public class FocusSystem : MonoBehaviour{
        [SerializeField] private float currentFocus; //esse serialize field é só pra facilitar o debug
        [SerializeField] private float initialFocus;
        [SerializeField] private float gainFocusPerSecond;

        private void Awake() {
            currentFocus = initialFocus;
        }

        private void Update() {
            currentFocus += gainFocusPerSecond * Time.deltaTime;
        }

        public float CurrentFocus {
            get => currentFocus;
            set {
                if (currentFocus < 0)
                    currentFocus = 0;
               
                else
                    currentFocus = value;
            }
        }
    }
}
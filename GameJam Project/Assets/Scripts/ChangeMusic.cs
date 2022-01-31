using UnityEngine;

namespace DefaultNamespace{
    public class ChangeMusic : MonoBehaviour{
        [SerializeField] private AudioClip _nextSong;
        private Camera _camera;
        private AudioSource _audioSource;

        private void Start() {
            _camera = Camera.main;
            _audioSource = _camera.GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.tag == "Player") {
                _audioSource.clip = _nextSong;
                _audioSource.Play();
            }
        }
        
    }
}
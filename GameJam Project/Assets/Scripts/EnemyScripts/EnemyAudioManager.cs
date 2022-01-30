using Entity;
using UnityEngine;

public class EnemyAudioManager : MonoBehaviour{
    [SerializeField] private AudioClip enemyDyingAudio;
    private AudioSource _audioSource;
    private Health _health;

    private void Awake() {
        _audioSource = GetComponent<AudioSource>();
        _health = GetComponent<Health>();
        _health.OnDiedEvent += PlayEnemyDyingAudio;
    }

    private void PlayEnemyDyingAudio() {
        _audioSource.clip = enemyDyingAudio;
        _audioSource.Play();
    }
}

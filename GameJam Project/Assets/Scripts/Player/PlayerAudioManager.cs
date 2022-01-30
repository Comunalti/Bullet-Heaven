using System;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour{
    [SerializeField] private AudioClip jumpSoundEffect;
    [SerializeField] private AudioClip playerDieSoundEffect;
    private AudioSource _audioSource;

    public static Action PlayerJumpingEvent;
    public static Action PlayerDyingEvent;

    private void Awake() {
        _audioSource = GetComponent<AudioSource>();

        PlayerJumpingEvent = PlayJumpSoundEffect;
        PlayerDyingEvent = PlayDieSoundEffect;
    }


    private void PlayJumpSoundEffect() {
        _audioSource.clip = jumpSoundEffect;
        _audioSource.Play();
    }
    
    private void PlayDieSoundEffect() {
        _audioSource.clip = playerDieSoundEffect;
        _audioSource.Play();
    }
}

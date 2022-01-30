using UnityEngine;

namespace Platforms
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(PlatformCollector))]
    public class PlatformCollectorAnimationHandler : MonoBehaviour
    {
        private Animator _animator;
        private PlatformCollector _platformCollector;
        private AudioSource _audioSource;
        
        private void Start() {
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();
            _platformCollector = GetComponent<PlatformCollector>();
            
            _platformCollector.PlatformCollectedEvent += OnPlatformCollected;
        }

        private void OnPlatformCollected()
        {
            _animator.SetTrigger("Collect");
        }

    }
}
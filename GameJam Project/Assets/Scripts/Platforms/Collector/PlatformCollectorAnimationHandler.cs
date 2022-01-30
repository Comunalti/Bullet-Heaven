using System;
using UnityEngine;

namespace Platforms
{
    [RequireComponent(typeof(PlatformCollector))]
    public class PlatformCollectorAnimationHandler : MonoBehaviour
    {
        private Animator _animator;
        private PlatformCollector _platformCollector;
        
        private void Start()
        {

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
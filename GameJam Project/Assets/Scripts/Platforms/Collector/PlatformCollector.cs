using System;
using DefaultNamespace;
using Player.Platforms;
using UnityEngine;

namespace Platforms
{
    public class PlatformCollector : MonoBehaviour
    {
        [SerializeField] private PlatformList platformList;
        [SerializeField] private PlatformTemplate platformTemplate;
        private Collider2D _collider2D;
        public event Action PlatformCollectedEvent;

        private void Start()
        {
            _collider2D = GetComponent<Collider2D>();
        }

        public void Destroy()
        {
            GameObject.Destroy(gameObject);
        }
        private void Collect()
        {
            platformList.Add(platformTemplate);
            Destroy(_collider2D);
            var player = GameObject.FindWithTag("Player").GetComponent<PlayerAudioManager>();
            player.PlayInteractEffect();
            PlatformCollectedEvent?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "Player")
            {
                Collect();
            }
        }
    }
}
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "new platform template",menuName = "Create Platform")]
    public class PlatformTemplate : ScriptableObject
    {
        public GameObject realPlatform;
        public GameObject ghostPlatform;
        public GameObject uiPlatform;
    }
}
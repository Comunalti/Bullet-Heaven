    
using UnityEngine;

namespace Player.Platforms
{
    public class PlatformPlacer : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private GameObject prefabGhost;
        [SerializeField] private GameObject prefabReal;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            
            var temp = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            temp.z = 0;
            prefabGhost.transform.position = temp;

        }
        
        
    }
}
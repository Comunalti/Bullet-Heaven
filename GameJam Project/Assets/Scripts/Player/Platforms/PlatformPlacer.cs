    
using UnityEngine;

namespace Player.Platforms
{
    public class PlatformPlacer : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private GameObject prefabGhost;
        [SerializeField] private GameObject prefabReal;
        [SerializeField] private InputReader inputReader;
        [SerializeField] private float rotationSpeed;
        [SerializeField] public GameObject platformUIPrefab;
        private void Start()
        {
            _camera = Camera.main;
            inputReader.MouseLeftClickChangedEvent += OnLeftClickChange;
            inputReader.MouseRightClickChangedEvent += OnRightClickChange;
            inputReader.MousePositionChangedEvent += MovePlatform;

        }

        private void OnLeftClickChange(bool value)
        {
            if (value)
            {
                Instantiate(prefabReal, prefabGhost.transform.position, prefabGhost.transform.rotation);
            }
        }

        private void OnRightClickChange(bool value)
        {
            if (value)
            {
                inputReader.MouseDeltaChangedEvent += RotatePlatform;
                inputReader.MousePositionChangedEvent -= MovePlatform;
                
            }
            else
            {
                inputReader.MouseDeltaChangedEvent -= RotatePlatform;
                inputReader.MousePositionChangedEvent += MovePlatform;
            }
        }
        

        private void MovePlatform(Vector2 mousePosition)
        {
            var temp = _camera.ScreenToWorldPoint(mousePosition);
            temp.z = 0;
            prefabGhost.transform.position = temp;
        }

        private void RotatePlatform(Vector2 delta)
        {
            prefabGhost.transform.Rotate(0,0,delta.x * rotationSpeed * Time.deltaTime);
        }
    }
}
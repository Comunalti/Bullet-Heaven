using System;
using DefaultNamespace;
using Player.Platforms.PlatformsBehaviour;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player.Platforms
{
    public class PlatformController : MonoBehaviour
    {
        private Camera _camera;

        private GameObject currentGhostInstance;
        private GameObject realPrefab;
        private PlatformTemplate currentPlatformTemplate;
        
        private InputReader inputReader;
        
        [SerializeField] private float rotationSpeed;

        [SerializeField] private PlatformList platformList;

        [SerializeField] private FocusSystem focusSystem;
        
        [SerializeField] private GameObject player;

        private float _currentAngle;
        private void Start()
        {
            _camera = Camera.main;

            inputReader = GameObject.FindObjectOfType<InputReader>();
            focusSystem = GameObject.FindObjectOfType<FocusSystem>();

            
            inputReader.MouseLeftClickChangedEvent += OnLeftClickChange;
            inputReader.MouseRightClickChangedEvent += OnRightClickChange;
            inputReader.MousePositionChangedEvent += MovePlatform;

            SetPlatformTemplate(currentPlatformTemplate);
        }

        private void OnDestroy()
        {
            inputReader.MouseLeftClickChangedEvent -= OnLeftClickChange;
            inputReader.MouseRightClickChangedEvent -= OnRightClickChange;
            inputReader.MousePositionChangedEvent -= MovePlatform;
        }

        public void SetPlatformTemplate(PlatformTemplate newPlatformTemplate)
        {

            if (currentGhostInstance != null)
            {
                Destroy(currentGhostInstance);
            }
            
            currentPlatformTemplate = newPlatformTemplate;

            currentGhostInstance = currentPlatformTemplate? currentPlatformTemplate.ghostPlatform?Instantiate(currentPlatformTemplate.ghostPlatform) : null : null;
            
            realPrefab = currentPlatformTemplate? currentPlatformTemplate.realPlatform : null;
            
        }

        private void OnLeftClickChange(bool value) {
            _currentAngle = 0;
            
            if (!currentGhostInstance) return;
            
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //print("esta em cima de um objeto");
                return;
            }
            if (value && focusSystem.CurrentFocus > currentPlatformTemplate.plataformCost)
            {
                var newPlatform = Instantiate(realPrefab, currentGhostInstance.transform.position, currentGhostInstance.transform.rotation);
                
                focusSystem.RemoveFocus(currentPlatformTemplate.plataformCost); 
                
                var platform = newPlatform.GetComponent<PlatformOwner>();
                if (platform != null)
                {
                    platform.owner = player;
                }
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
                OnLeftClickChange(true);
            }
        }
        
        private void MovePlatform(Vector2 mousePosition)
        {
            if (currentGhostInstance is null)
                return;
            var temp = _camera.ScreenToWorldPoint(mousePosition);
            temp.z = 0;
            currentGhostInstance.transform.position = temp;
        }

        private void RotatePlatform(Vector2 delta)
        {
            _currentAngle += delta.x * rotationSpeed * Time.deltaTime;
        }

        private void Update()
        {
            if (!currentGhostInstance) return;
            
            currentGhostInstance.transform.rotation = Quaternion.Euler(0,0,_currentAngle);
        }
    }
}
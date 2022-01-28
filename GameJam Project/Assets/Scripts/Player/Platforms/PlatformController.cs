using DefaultNamespace;
using Player.Platforms.PlatformsBehaviour;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player.Platforms
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject platformUIPrefab;

        private GameObject ghostInstance;
        private GameObject realPrefab;

        
        [SerializeField] private PlatformTemplate platformTemplate;
        [SerializeField] private InputReader inputReader;
        
        [SerializeField] private float rotationSpeed;

        [SerializeField] private PlatformList platformList;

        private float _angle;
        [SerializeField] private GameObject player;

        private void Start()
        {
            _camera = Camera.main;
            inputReader.MouseLeftClickChangedEvent += OnLeftClickChange;
            inputReader.MouseRightClickChangedEvent += OnRightClickChange;
            inputReader.MousePositionChangedEvent += MovePlatform;

            SetPlatformTemplate(platformTemplate);
        }

        
        public void SetPlatformTemplate(PlatformTemplate newPlatformTemplate)
        {

            if (ghostInstance != null)
            {
                Destroy(ghostInstance);
            }
            
            platformTemplate = newPlatformTemplate;

            ghostInstance = platformTemplate? platformTemplate.ghostPlatform?Instantiate(platformTemplate.ghostPlatform) : null : null;
            realPrefab = platformTemplate? platformTemplate.realPlatform : null;
            
        }

        private void OnLeftClickChange(bool value) {
            var focusSystem = player.GetComponent<FocusSystem>();
            _angle = 0;
            
            if (EventSystem.current.IsPointerOverGameObject())
            {
                print("esta em cima de um objeto");
                return;
            }
            if (value && focusSystem.CurrentFocus > platformTemplate.plataformCost)
            {
                var newPlatform = Instantiate(realPrefab, ghostInstance.transform.position, ghostInstance.transform.rotation);
                
                focusSystem.CurrentFocus -= platformTemplate.plataformCost;
                
                var platform = newPlatform.GetComponent<Platform>();
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
            if (ghostInstance is null)
                return;
            var temp = _camera.ScreenToWorldPoint(mousePosition);
            temp.z = 0;
            ghostInstance.transform.position = temp;
        }

        private void RotatePlatform(Vector2 delta)
        {
            _angle += delta.x * rotationSpeed * Time.deltaTime;
        }

        private void Update()
        {
            ghostInstance.transform.rotation = Quaternion.Euler(0,0,_angle);
        }
    }
}
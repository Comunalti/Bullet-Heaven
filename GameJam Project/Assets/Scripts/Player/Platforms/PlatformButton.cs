using DefaultNamespace;
using Player.Platforms;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlatformButton :  MonoBehaviour
{
    private Button _button;
    private PlatformController _platformController;
    [SerializeField] private PlatformTemplate platformTemplate;
    
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
        _platformController = FindObjectOfType<PlatformController>();
        if (platformTemplate is null)
        {
            Debug.Log("sem 'plataform template' na UI");
        }
    }

    public void OnClick()
    {
        _platformController.SetPlatformTemplate(platformTemplate);
    }
    
}
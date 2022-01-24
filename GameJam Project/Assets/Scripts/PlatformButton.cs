using Player.Platforms;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlatformButton :  MonoBehaviour
{
    private Button _button;
    private PlatformPlacer _connectedPlatform;
    private PlatformManager _platformManager;
    private void Start()
    {
        _platformManager = GameObject.FindObjectOfType<PlatformManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        foreach (Transform child in _platformManager.transform)
        {
            child.gameObject.SetActive(false);
        }
        _connectedPlatform.gameObject.SetActive(true);
    }
    public void Connect(PlatformPlacer platform)
    {
        _connectedPlatform = platform;
    }
}
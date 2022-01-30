using UnityEngine;
using UnityEngine.UI;

public class LeaveGameButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);    
    }

    void OnClick()
    {
        Application.Quit();
    }

}

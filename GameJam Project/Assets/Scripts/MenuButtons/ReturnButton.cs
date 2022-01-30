using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class ReturnButton : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);    
    }

     void OnClick()
     {
         FindObjectOfType<InputReader>().UnPause();
     }
    
}

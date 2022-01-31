using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDestroyer : MonoBehaviour
{
    public GameObject canvas;
    void Start()
    {
        Time.timeScale = 0;
        GetComponent<Button>().onClick.AddListener(DestroyCanvas);
    }

    private void DestroyCanvas()
    {
        Time.timeScale = 1;
        Destroy(canvas);
    }
}

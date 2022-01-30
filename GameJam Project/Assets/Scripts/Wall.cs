using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private CameraTarget _camera;
    void Start()
    {
        _camera = FindObjectOfType<CameraTarget>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _camera.SetWall(this);
        }
    }
}
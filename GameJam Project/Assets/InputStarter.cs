using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class InputStarter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.OnEnable();
    }
}

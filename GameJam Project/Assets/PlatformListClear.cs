using System;
using System.Collections;
using System.Collections.Generic;
using Player.Platforms;
using UnityEngine;

public class PlatformListClear : MonoBehaviour
{
    [SerializeField] private PlatformList platformList;

    private void Awake()
    {
        platformList.platformTemplates.Clear();
    }
}

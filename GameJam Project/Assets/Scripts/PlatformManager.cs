using System;
using System.Collections;
using System.Collections.Generic;
using Player.Platforms;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject uiGrid;

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        ResetUI();
        foreach (Transform child in transform)
        {
            AddUI(child);
        }
    }

    private void AddUI(Transform child)
    {
        var platform = child.GetComponent<PlatformPlacer>();
        var platformUI = Instantiate(platform.platformUIPrefab,uiGrid.transform);

        var platformButton = platformUI.GetComponent<PlatformButton>();
        platformButton.Connect(platform);
    }

    private void ResetUI()
    {
        foreach (Transform child in uiGrid.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void OnTransformChildrenChanged()
    {
        UpdateUI();
    }
}
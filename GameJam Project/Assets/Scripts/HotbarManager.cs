using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HotbarManager : MonoBehaviour
{
    private void OnTransformChildrenChanged()
    {
        if (transform.childCount > 0)
        {
            if (!EventSystem.current.alreadySelecting)
            {
                EventSystem.current.SetSelectedGameObject(transform.GetChild(0).gameObject);
            }
        }
    }

    private void Update()
    {
        if (transform.childCount > 0)
        {
            if (!EventSystem.current.firstSelectedGameObject)
            {
                EventSystem.current.SetSelectedGameObject(transform.GetChild(0).gameObject);
            }
        }
    }
}

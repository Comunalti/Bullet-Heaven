using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationDestroyer : MonoBehaviour
{
    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}

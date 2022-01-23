using System;
using UnityEngine;

namespace Player
{
    public class StateHandler : MonoBehaviour
    {
        private void Start()
        {
            foreach (var playerState in GetComponents<PlayerState>())
            {
                //playerState.
            }
        }
    }
}
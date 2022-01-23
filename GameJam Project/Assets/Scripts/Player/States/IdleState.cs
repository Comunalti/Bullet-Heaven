using System;
using UnityEngine;

namespace Player.States
{
    public class IdleState : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            throw new NotImplementedException();
        }

        private void Update()
        {
            throw new NotImplementedException();
        }
    }
}
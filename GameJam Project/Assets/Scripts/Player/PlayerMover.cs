using System;
using Input;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EntityMover : MonoBehaviour
    {
        private new Rigidbody2D rigidbody2D;

        //public Entity entity;
        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Move(float horizontal)
        {
            //rigidbody2D.MovePosition(Vector2.right * (horizontal * entity.HorizontalSpeed * Time.deltaTime));
        }

        public void DashToDirectionWithForce(Vector2 direction, float force)
        {
            rigidbody2D.AddForce(direction*force,ForceMode2D.Impulse);
        }
        
        
        
        
    }
}
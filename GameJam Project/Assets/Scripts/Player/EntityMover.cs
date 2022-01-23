using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EntityMover : MonoBehaviour
    {
        private new Rigidbody2D rigidbody2D;
        [SerializeField] private float speed;

        //public Entity entity;
        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Move(float horizontal)
        {
            rigidbody2D.velocity = new Vector2((horizontal * speed),rigidbody2D.velocity.y) ;
        }

        public void DashToDirectionWithForce(Vector2 direction, float force)
        {
            rigidbody2D.AddForce(direction*force,ForceMode2D.Impulse);
        }
        
        
        
        
    }
}
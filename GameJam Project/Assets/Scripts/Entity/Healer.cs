using System;
using UnityEngine;

namespace Entity
{
    public class Healer : MonoBehaviour
    {
        public int quantity;
        private void OnCollisionEnter2D(Collision2D other)
        {

            var health = other.gameObject.GetComponent<Health>();
            if (health)
            {
                for (int i = 0; i < quantity; i++)
                {
                    health.Add();
                }
                Destroy(gameObject);
            }
        }
    }
}
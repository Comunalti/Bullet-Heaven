using System;
using System.Linq;
using UnityEngine;

namespace Player.Checkers
{
    [RequireComponent(typeof(Rigidbody2D),typeof(Transform),typeof(CapsuleCollider2D))]
    public class GroundedChecker : MonoBehaviour
    {
        [field: SerializeField]
        public bool IsGrounded { get; private set; }
        [SerializeField][Range(0,0.5f)]
        private float distance = 0.18f;
        Rigidbody2D _rigidbody2D;
        private Transform _transform;
        private CapsuleCollider2D _capsuleCollider2D;
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _transform = GetComponent<Transform>();
            _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            var isGroundedLastFrame = IsGrounded;
            var raycastHit2D = Physics2D.CapsuleCastAll(_capsuleCollider2D.bounds.center,_capsuleCollider2D.size,_capsuleCollider2D.direction,0,
                Vector2.down,distance);
            var a = raycastHit2D.Where(a => a.transform != _transform && !a.collider.isTrigger);
            
            IsGrounded = a.Count() != 0;
            if (isGroundedLastFrame != IsGrounded && IsGrounded)
            {
                GroundTouchedEvent?.Invoke();
            }
        }

        public event Action GroundTouchedEvent;
    }
}
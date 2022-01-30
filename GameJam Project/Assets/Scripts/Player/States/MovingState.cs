using System;
using UnityEngine;
using Player.Checkers;

namespace Player.States
{
    [RequireComponent(typeof(EntityMover),typeof(Rigidbody2D),typeof(GroundedChecker))]
    public class MovingState : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private EntityMover _entityMover;
        private GroundedChecker _groundedChecker;
        private float horizontalInput;
        private bool spaceBarPress;
        private Animator _animator;

        [SerializeField] private InputReader inputReader;
        [SerializeField] private float jumpForce;

        [SerializeField] private float divider;
        public void OnHorizontalInputChanged(float newHorizontalInput)
        {
            horizontalInput = newHorizontalInput;
        }
        public void OnJumpInputChanged(bool newSpaceBarPress)
        {
            spaceBarPress = newSpaceBarPress;

            if (newSpaceBarPress)
            {
                StartJump();
            }
            else
            {
                EndJump();
            }
        }

        private void OnGroundTouchChanged(bool isTouching)
        {
            if (isTouching)
            {
                _animator.SetBool("isJumping", false);
                _animator.SetBool("isFalling", false);
            }
            else
            {
                _animator.SetBool("isFalling", true);

            }
            
        }

        private void EndJump()
        {
            var temporaryVelocity = _rigidbody2D.velocity;
            if (temporaryVelocity.y>0)
            {
                _rigidbody2D.velocity = new Vector2(temporaryVelocity.x, temporaryVelocity.y / divider);
            }
        }

        private void StartJump()
        {
            if (_groundedChecker.IsGrounded)
            {
                _rigidbody2D.velocity = _rigidbody2D.velocity + (Vector2.up * jumpForce);
                _animator.SetBool("isJumping", true);
                
            }
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _entityMover = GetComponent<EntityMover>();
            _groundedChecker = GetComponent<GroundedChecker>();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            inputReader.HorizontalChangedEvent += OnHorizontalInputChanged;
            inputReader.JumpChangedEvent += OnJumpInputChanged;
            _groundedChecker.GroundTouchChangedEvent += OnGroundTouchChanged;
        }

        private void OnDisable()
        {
            inputReader.HorizontalChangedEvent -= OnHorizontalInputChanged;
            inputReader.JumpChangedEvent -= OnJumpInputChanged;
            _groundedChecker.GroundTouchChangedEvent -= OnGroundTouchChanged;
        }

        private void Update()
        {   
            _entityMover.Move(horizontalInput);
            var isWalking = horizontalInput == -1 || horizontalInput == 1;
            _animator.SetBool("isWalking", isWalking);

            if (horizontalInput == 1) 
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (horizontalInput == -1) 
                transform.rotation = Quaternion.Euler(0, 180, 0);

            // if (_rigidbody2D.velocity.y < 0)
            // {
            //     _animator.SetBool("isFalling", true);
            // }
                
        }
    }
}
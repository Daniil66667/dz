using UnityEngine;

namespace YOUR_NAME
{
    public class Movement : MonoBehaviour
    {
        private static readonly Vector3 ForwardRotation = new(0f, 0f, 0f);
        private static readonly Vector3 BackwardRotation = new(0f, 180f, 0f);
        
        [SerializeField] private Ground ground;
        
        [Space]
        [SerializeField] private Walking walking;
        [SerializeField] private Jumping jumping;

        [SerializeField] private CharacterAnimator animator;
        
        public void Move(Vector2 direction)
        {
            walking.Move(direction);
            
            var character = transform;
            character.eulerAngles = GetVelocity().x switch
            {
                > 0 => ForwardRotation,
                < 0 => BackwardRotation,
                _ => character.eulerAngles
            };
        }

        private void OnLand()
        {
            animator.SetIsFalling(true);
        }

        private void OnJump()
        {
            animator.Jump();
        }

        private void OnEnable()
        {
            ground.onLeave += OnJump;
            ground.onLanded += OnLand;
        }
        
        private void OnDisable()
        {
            ground.onLeave -= OnJump;
            ground.onLanded -= OnLand;
        }
        
        private void FixedUpdate()
        {
            animator.SetVelocity(GetVelocity());
            animator.SetIsFalling(!ground.IsOnGround && GetVelocity().y<=0);
        }

        public void DoJump()
        {
            jumping.Jump();
        }
        
        public Vector2 GetVelocity()
        {
            return walking.Velocity;
        }
        
        public float GetSpeed()
        {
            return walking.Speed;
        }

        public bool IsFalling()
        {
            return !ground.IsOnGround;
        }
    }
}
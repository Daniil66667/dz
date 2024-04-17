using UnityEngine;
[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
   private Animator _animator;
  
   [SerializeField] private string speedParameterName = "Speed";
   [SerializeField] private string jumpTriggerName = "Jump";
   [SerializeField] private string isFallingParameterName
       = "IsFalling";
   [SerializeField] private string hurtTriggerName = "Hurt";


   private void Awake()
   {
       _animator = GetComponent<Animator>();
   }


   public void SetVelocity(Vector2 velocity)
   {
       _animator.SetFloat(speedParameterName, velocity.magnitude);
   }


   public void SetIsFalling(bool isFalling)
   {
       _animator.SetBool(isFallingParameterName, isFalling);
   }
  
   public void Jump()
   {
      _animator.SetTrigger(jumpTriggerName);
   }


   public void Hurt()
   {
       _animator.SetTrigger(hurtTriggerName);
   }
}

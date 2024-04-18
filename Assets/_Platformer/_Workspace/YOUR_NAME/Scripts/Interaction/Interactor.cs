using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
   //...
   private void SetupInputManager(IInputManager inputManager)
   {
      //...
      inputManager.onInteract += OnInteract;
   }
   private void RemoveInputManager(IInputManager inputManager)
   {
      //...
      inputManager.onInteract -= OnInteract;
   }


   private void OnInteract()
   {
      interactor.Interact();
   }
}

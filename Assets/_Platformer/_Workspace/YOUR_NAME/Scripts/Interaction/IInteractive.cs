using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public interface IInteractive
{
   int Priority { get; }
   void Interact(Interactor instigator);
   bool CanInteractWith(Interactor instigator);
}



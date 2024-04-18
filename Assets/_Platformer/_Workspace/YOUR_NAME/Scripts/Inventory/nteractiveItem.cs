using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class InteractiveItem : MonoBehaviour, IInteractive
{
   [SerializeField] private Item item;
   [Space]
   [SerializeField] private UnityEvent onPickedUp;


   private Item _instance;
   public int Priority => 255;


   private void OnValidate()
   {
       if (item)
       {
           GetComponent<SpriteRenderer>().sprite = item.Sprite;
       }
   }
   private void Awake()
   {
       _instance = Instantiate(item);
   }
   private void OnEnable()
   {
       _instance.onPickedUp += OnPickedUp;
   }
   private void OnDisable()
   {
       _instance.onPickedUp -= OnPickedUp;
   }
   private void OnPickedUp(Item pickedItem)
   {
       onPickedUp.Invoke();
       if (pickedItem.Amount == 0) gameObject.SetActive(false);
   }
   public void Interact(Interactor instigator)
   {
      if (!instigator) return;
      var inventory = instigator.GetComponent<Inventory>();
      if (!inventory) inventory.PickUp(_instance)
   }
}


using UnityEngine;

public class Item : InteractableObject
{
    [SerializeField] private Inventory _invetory;
    public override void Interact()
    {
        _invetory.AddItem(this);
        gameObject.SetActive(false);
    }
}


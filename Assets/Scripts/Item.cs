
using UnityEngine;

public class Item : InteractableObject
{
    [SerializeField] protected Inventory _invetory;

    private void Awake()
    {
        _invetory = GameObject.FindFirstObjectByType<Inventory>();
    }
    public override void Interact()
    {
        _invetory.AddItem(this);
        gameObject.SetActive(false);
    }
}


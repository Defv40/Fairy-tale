
using UnityEngine;

public class Key : Item
{
    
    public override void Interact()
    {
        _invetory.AddItem(this);
        Debug.Log("this key");
        gameObject.SetActive(false);
        
    }
}


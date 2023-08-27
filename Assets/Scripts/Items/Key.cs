
using UnityEngine;

public class Key : Item
{
    
    public override void Interact()
    {
        //SoundSystem.Instance.PlaySound(_sounds[0], 1, false, 1, 1);
        
       _invetory.AddItem(this);
        Debug.Log("this key");
       
        gameObject.SetActive(false);
        
    }
}


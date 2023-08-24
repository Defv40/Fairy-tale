using UnityEngine;

public class Flower : Item
{   
    public override void Interact()
    {
        
        SoundSystem.Instance.PlaySound(_sounds[0]);
        base.Interact();
    }
}


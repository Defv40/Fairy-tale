
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Chest : InteractableObject
{
    private Animator _animator;

    private void Awake()
    {
       
        _animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        _animator.SetTrigger("Interact");
        SoundSystem.Instance.PlaySound(_sounds[0]);
        //gameObject.layer = LayerMask.NameToLayer("Default");
    }
}

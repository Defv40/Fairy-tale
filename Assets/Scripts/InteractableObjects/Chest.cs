
using UnityEngine;

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

        gameObject.layer = LayerMask.NameToLayer("Default");
    }
}


using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Chest : InteractableObject
{
    private Animator _animator;
    [SerializeField] private Key _keyInChest;
    private void Awake()
    {
       
        _animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        _animator.SetTrigger("Interact");
        SoundSystem.Instance.PlaySound(_sounds[0]);
        _keyInChest?.Interact();
        _keyInChest = null;
        //gameObject.layer = LayerMask.NameToLayer("Default");
    }
}


using UnityEngine;

[RequireComponent (typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class Chest : InteractableObject
{
    private Animator _animator;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        _animator.SetTrigger("Interact");
        _audioSource.Play();
        //gameObject.layer = LayerMask.NameToLayer("Default");
    }
}

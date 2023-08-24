
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    public abstract void Interact();
    [SerializeField] protected AudioSource _audioSource;
}

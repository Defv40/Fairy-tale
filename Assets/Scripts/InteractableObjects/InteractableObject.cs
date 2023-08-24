
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] protected AudioClip[] _sounds;
    public abstract void Interact();
   
}

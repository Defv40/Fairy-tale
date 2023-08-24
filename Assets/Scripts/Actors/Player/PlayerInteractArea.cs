using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerInteractArea : MonoBehaviour, IObserver
{
    [SerializeField] private bool objectInInteractArea = false; // объект в зоне взаимодействия с игроком
    [SerializeField] private Collider objectForInteract;

    private void OnEnable()
    {
        NotificationCenter.Intastance.AddObserver(this);
    }

    private void OnDisable()
    {
        NotificationCenter.Intastance.RemoveObserver(this);
    }

    public void TryInteract()
    {
        if (!objectInInteractArea) return;

        var interactable = objectForInteract.GetComponent<IInteractable>();

        if (interactable != null)
        {
            interactable.Interact();
            objectInInteractArea = false;
            objectForInteract = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        objectInInteractArea = true;
        objectForInteract = other;
    }

    private void OnTriggerExit(Collider other)
    {
        objectInInteractArea = false;
        objectForInteract = null;
    }

    public void OnNotify(EventType type)
    {
        if (type == EventType.OnInteract)
        {
            TryInteract();
        }
    }
}
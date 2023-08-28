
using System.Linq;
using UnityEngine;

public class UIModalNotification : UIModal
{
    [SerializeField] private GameObject[] interfaceInteract;

    public override void OnNotify(EventType type)
    {
        switch (type)
        {
            case EventType.OnInteractObjectEnter:
                interfaceInteract.ToList().ForEach(i => i.SetActive(true));
                break;
            case EventType.OnInteractObjectExit:
                interfaceInteract.ToList().ForEach(i => i.SetActive(false));
                break;
            case EventType.OnInteractObjectStay:
                interfaceInteract.ToList().ForEach(i => i.SetActive(true));
                break;

        }
    }
}

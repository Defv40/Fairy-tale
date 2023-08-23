
using UnityEngine;

public class PlayerInteractArea : MonoBehaviour
{

  
    private void OnTriggerExit(Collider other)
    {

        NotificationCenter.Intastance.NotifyObserver(EventType.OnInteractObjectExit);
    }

    private void OnTriggerStay(Collider other)
    {
        NotificationCenter.Intastance.NotifyObserver(EventType.OnInteractObjectStay);
    }
}
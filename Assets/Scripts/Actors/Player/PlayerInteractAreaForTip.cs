
using UnityEngine;

public class PlayerInteractAreaForTip : MonoBehaviour
{

  
    private void OnTriggerExit(Collider other)
    {

        NotificationCenter.Intastance.NotifyObserver(EventType.OnInteractObjectExit);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        NotificationCenter.Intastance.NotifyObserver(EventType.OnInteractObjectStay);
    }
}
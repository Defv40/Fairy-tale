
using UnityEngine;

public class PlayerInteractAreaForTip : MonoBehaviour
{
    [SerializeField] private Collider objectTipping;
  
    private void OnTriggerExit(Collider other)
    {
      
        NotificationCenter.Intastance.NotifyObserver(EventType.OnInteractObjectExit);
    }

    private void OnTriggerEnter(Collider other)
    {
        objectTipping = other;
        NotificationCenter.Intastance.NotifyObserver(EventType.OnInteractObjectStay);
    }
}
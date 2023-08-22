using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractArea : MonoBehaviour
{



    //private void OnTriggerEnter(Collider other)
    //{

    //    NotificationCenter.Intastance.NotifyObserver(EventType.OnInteractObjectEnter);
    //}
    private void OnTriggerExit(Collider other)
    {

        NotificationCenter.Intastance.NotifyObserver(EventType.OnInteractObjectExit);
    }

    private void OnTriggerStay(Collider other)
    {
        NotificationCenter.Intastance.NotifyObserver(EventType.OnInteractObjectStay);
    }
}
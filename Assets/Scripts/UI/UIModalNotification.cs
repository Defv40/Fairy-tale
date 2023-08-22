using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIModalNotification : UIModal
{
    [SerializeField] private GameObject exclamationMark;

    public override void OnNotify(EventType type)
    {
        switch (type)
        {
            case EventType.OnInteractObjectEnter:
                exclamationMark.SetActive(true);
                break;
            case EventType.OnInteractObjectExit:
                exclamationMark.SetActive(false);
                break;
            case EventType.OnInteractObjectStay:
                exclamationMark.SetActive(true);
                break;

        }

        
        //gameObject.SetActive(true);
    }
}

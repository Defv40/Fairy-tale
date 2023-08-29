using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheskMusic : MonoBehaviour
{
    private void Awake()
    {
        DontDestroy[] obj = GameObject.FindObjectsByType<DontDestroy>(FindObjectsSortMode.None);
        if (obj.Length > 1)
        {
            Destroy(obj[1].gameObject);
        }
     
    }
}

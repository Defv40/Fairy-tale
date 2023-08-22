using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour, IObserver
{
    [SerializeField] private List<UIItem> _uiInventory = new List<UIItem>();
   
    [SerializeField] private UIItem _itemPrefab;
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        NotificationCenter.Intastance.AddObserver(this);
    }
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNotify(EventType type)
    {
        if (type == EventType.OnPickItem)
        {
           
        }
    }
}

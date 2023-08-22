using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField][Range(0, 10)] private int _inventoryCapacity;
    [SerializeField] private List<Item> _inventory;
    public List<Item> PlayerInventory
    {
        get { return _inventory; }
        private set { _inventory = value; }
    }

    private PlayerControls _playerControls;
    private Player _player;
    private void OnEnable()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
      
     
    }
    private void Awake()
    {
        _inventory = new List<Item>(_inventoryCapacity);
    }
    private void OnDisable()
    {
        
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
        NotificationCenter.Intastance.NotifyObserver(EventType.OnPickItem);
    }

   
}

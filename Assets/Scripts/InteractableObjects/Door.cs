
using UnityEngine;

public class Door : InteractableObject
{
    private Inventory _playerInventory;

    private void Awake()
    {
        _playerInventory = GameObject.FindAnyObjectByType<Inventory>();  
    }
    public override void Interact()
    {

        var item = _playerInventory.PlayerInventory.Find((item) => item is Key);
        if (item != null)
        {
            _playerInventory.PlayerInventory.Remove(item);
            NotificationCenter.Intastance.NotifyObserver(EventType.OnRemoveItemFromInventory);
            GameObject.Destroy(gameObject);
        }
        else
        {
            print("Нет Ключа");
        }
        


    }
}


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
            print("Я удали ключ");
        }
        else
        {
            print("Нет Ключа");
        }
        //if (_playerInventory.PlayerInventory.Exists((item) => item is Key))
        //{
        //    _playerInventory.PlayerInventory.Remove(

        //    );
        //}


    }
}

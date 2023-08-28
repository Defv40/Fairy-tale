
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CampFire : InteractableObject
{
    private Inventory _playerInventory;
    [SerializeField] private List<FireFly> fireFlies = new List<FireFly>();
    [SerializeField] private Key _key;
    private void Awake()
    {
        _playerInventory = GameObject.FindAnyObjectByType<Inventory>();  
    }
    public override void Interact()
    {

        int item = _playerInventory.PlayerInventory.Count((item) => item is FireFly);

        if (item >= 5)
        {
            Debug.Log("Хватает проходи на новый уровень!");
            _playerInventory.PlayerInventory.RemoveAll((item) => item is FireFly);
            fireFlies.ForEach((item) => Destroy(item.gameObject));
            NotificationCenter.Intastance.NotifyObserver(EventType.OnRemoveItemFromInventory);
            _key?.Interact();
            _key = null;
            
        }
        else
        {
            Debug.Log("Не хватает нужно больше светлячков, " + $"У вас сейчас {item}"); ;
        }
   


    }
}

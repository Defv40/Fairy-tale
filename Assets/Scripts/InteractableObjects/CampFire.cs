
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CampFire : InteractableObject
{
    private Inventory _playerInventory;
    [SerializeField] private List<FireFly> fireFlies = new List<FireFly>();
    [SerializeField] private Key _key;
    [SerializeField] private GameObject _fireFlies; // удалим всех если пройдем уровень
    private NotifyUserText _tipText;
    [SerializeField] private string _textForTip = "Мне нужно больше светлячков";
    private void Awake()
    {
        _playerInventory = GameObject.FindAnyObjectByType<Inventory>();
        _tipText = GameObject.FindAnyObjectByType<NotifyUserText>();
    }
    public override void Interact()
    {

        int item = _playerInventory.PlayerInventory.Count((item) => item is FireFly);

        if (item >= 5)
        {
            Debug.Log("Хватает проходи на новый уровень!");
            SoundSystem.Instance.PlaySound(_sounds[0], .5f);
            _playerInventory.PlayerInventory.RemoveAll((item) => item is FireFly);
            fireFlies.ForEach((item) => Destroy(item.gameObject));
            NotificationCenter.Intastance.NotifyObserver(EventType.OnRemoveItemFromInventory);
            _key?.Interact();
            _key = null;
            Destroy(_fireFlies);


        }
        else
        {
            Debug.Log("Не хватает нужно больше светлячков, " + $"У вас сейчас {item}");
            NotificationCenter.Intastance.NotifyObserver(EventType.OnShowTip);
            _tipText.Tip(_textForTip);
        }
   


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IInteractable
{


    private Inventory _playerInventory;

    private void Awake()
    {
        _playerInventory = FindAnyObjectByType<Inventory>();
    }

    private void Start()
    {
        Blackout.Inst.Pass(false, 0.35f, _event: () =>
        {
            Player.Instance.SetMove = true;
        });
    }
    public void GoToTheNextLevel()
    {
        int indexNextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadSceneAsync(indexNextLevel, LoadSceneMode.Single);
    }

    public void Interact()
    {
        var item = _playerInventory.PlayerInventory.Find((Item item) => item is Key);
        if (item != null)
        {
            _playerInventory.PlayerInventory.Remove(item);
            NotificationCenter.Intastance.NotifyObserver(EventType.OnRemoveItemFromInventory);
            NotificationCenter.Intastance.NotifyObserver(EventType.OnCompleteLevel);
        }
      
    }
}

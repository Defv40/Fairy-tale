
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour, IObserver
{
    private List<UIItem> _uiInventory = new List<UIItem>();

    private Inventory _inventory;

    [SerializeField] private Dictionary<string, Sprite> _itemIcons = new Dictionary<string, Sprite>();
    [SerializeField] private List<Sprite> _allIconsForInventory;
    [SerializeField] private UIItem _itemPrefab;
    private void OnEnable()
    {
        NotificationCenter.Intastance.AddObserver(this);
    }

    private void OnDisable()
    {
       NotificationCenter.Intastance.RemoveObserver(this);
    }
    private void Awake()
    {
        _inventory = GameObject.FindFirstObjectByType<Inventory>();
    
    }
    private void Start()
    {
        FillItemIcons();
    }
    private void FillItemIcons()
    {
        
        _itemIcons.Add(nameof(Key), _allIconsForInventory[0]);
        _itemIcons.Add(nameof(Mice), _allIconsForInventory[1]);
        _itemIcons.Add(nameof(Wallet), _allIconsForInventory[2]);
        _itemIcons.Add(nameof(Flower), _allIconsForInventory[3]);
    }

    public void ClearChildren()
    {
        Debug.Log(transform.childCount);
        int i = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Now destroy them
        foreach (GameObject child in allChildren)
        {
            Destroy(child.gameObject);
        }

        Debug.Log(transform.childCount);
    }

    private void FillUiInventory()
    {
        ClearChildren();

        foreach (Item item in _inventory.PlayerInventory)
        {
            Sprite icon = _itemIcons[item.GetType().ToString()];

            _itemPrefab.GetComponent<Image>().sprite = icon;

            Instantiate(_itemPrefab.gameObject, transform);
        }
    }

    public void OnNotify(EventType type)
    {
        if (type == EventType.OnPickItem)
        {

            FillUiInventory();
            return;
        }

        if (type == EventType.OnRemoveItemFromInventory)
        {
            FillUiInventory();
            return;
        }
    }
}

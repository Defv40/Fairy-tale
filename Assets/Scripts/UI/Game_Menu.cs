using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Menu : MonoBehaviour
{
    public static Game_Menu Instance { get; private set; }

    public bool isActived { get; private set; }
    [SerializeField] private GameObject[] elementsMenu;
    private Image image;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        image = GetComponent<Image>();
        isActived = false;
        DisableAll();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isActived) DisableAll();
            else Enable();
        }
    }

    public void Enable()
    {
        isActived = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
        image.enabled = true;
        elementsMenu[0].SetActive(true);
    }
    public void DisableAll()
    {
        isActived = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        image.enabled = false;
        foreach (var element in elementsMenu)
        {
            element.SetActive(false);
        }
    }
}

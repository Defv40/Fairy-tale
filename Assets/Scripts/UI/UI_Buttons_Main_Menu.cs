
using UnityEngine;


public class UI_Buttons_Main_Menu : MonoBehaviour
{
    [SerializeField] private GameObject o_settings;

    public void NewGame_OnClick()
    {
        // переключение на 1 уровень
    }
    public void Settings_OnClick()
    {
        o_settings.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Quit_OnClick() => Application.Quit();
}
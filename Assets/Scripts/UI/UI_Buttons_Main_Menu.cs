
using UnityEngine;


public class UI_Buttons_Main_Menu : MonoBehaviour
{
    [SerializeField] private GameObject o_load;
    [SerializeField] private GameObject o_settings;

    public void NewGame_OnClick()
    {

    }

    public void Load_OnClick()
    {
        o_load.SetActive(!o_load.activeSelf);
    }

    public void Settings_OnClick()
    {
        o_settings.SetActive(true);
        o_load.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Quit_OnClick() => Application.Quit();
}


using UnityEngine;

public class UI_Buttons_Settings : MonoBehaviour
{
    [SerializeField] private GameObject o_menu;
    [SerializeField] private GameObject o_volume;
    [SerializeField] private GameObject o_video;
    [SerializeField] private GameObject o_graphic;

    private void DisableAllAdditionalWindows()
    {
        o_volume.SetActive(false);
        o_video.SetActive(false);
        o_graphic.SetActive(false);
    }

    public void Back_OnClick()
    {
        o_menu.SetActive(true);
        DisableAllAdditionalWindows();
        gameObject.SetActive(false);
    }

    public void Volume_OnClick()
    {
        DisableAllAdditionalWindows();
        o_volume.SetActive(true);
    }

    public void Video_OnClick()
    {
        DisableAllAdditionalWindows();
        o_video.SetActive(true);
    }

    public void Graphic_OnClick()
    {
        DisableAllAdditionalWindows();
        o_graphic.SetActive(true);
    }

    public void Save_OnClick() 
    {
        Global_Settings.Init.Save();
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UI_Buttons_Game_Menu : MonoBehaviour
{
    [SerializeField] private GameObject o_settings;

    public void Continue_OnClick() => Game_Menu.Instance.DisableAll();

    public void Settings_OnClick()
    {
        o_settings.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Main_Menu_OnClick()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}

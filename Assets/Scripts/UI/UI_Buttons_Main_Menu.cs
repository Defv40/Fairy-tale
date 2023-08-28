
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons_Main_Menu : MonoBehaviour
{
    [SerializeField] private GameObject o_settings;

    public void NewGame_OnClick()
    {
        Blackout.Inst.Pass(true, _event: () => SceneManager.LoadScene(1, LoadSceneMode.Single));
        
    }
    public void Settings_OnClick()
    {
        o_settings.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Quit_OnClick() => Application.Quit();
}
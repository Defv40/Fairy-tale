
using UnityEngine;
using UnityEngine.UI;

public class UI_Controls_Settings_Volume : MonoBehaviour
{
    [SerializeField] private Slider globalVolume;
    [SerializeField] private Slider musicVolume;
    [SerializeField] private Slider soundsVolume;

    private void Start()
    {
        globalVolume.value = Global_Settings.Init.globalVolume;
        musicVolume.value = Global_Settings.Init.musicVolume;
        soundsVolume.value = Global_Settings.Init.soundsVolume;
    }

    public void GlobalVolume_Slider_OnChanged(float value)
    {
        Global_Settings.Init.globalVolume = value;
    }

    public void MusicVolume_Slider_OnChanged(float value)
    {
        Global_Settings.Init.musicVolume = value;
    }

    public void SoundsVolume_Slider_OnChanged(float value)
    {
        Global_Settings.Init.soundsVolume = value;
    }
}

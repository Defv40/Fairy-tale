
using UnityEngine;

public class UI_Controls_Settings_Volume : MonoBehaviour
{
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

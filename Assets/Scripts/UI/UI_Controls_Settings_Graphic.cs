
using UnityEngine;

public class UI_Controls_Settings_Graphic : MonoBehaviour
{
    public void Textures_DropDown_OnChanged(int value)
    {
        Global_Settings.Init.textureResolition = value;
    }

    public void Shadow_DropDown_OnChanged(int value)
    {
        Global_Settings.Init.shadowResolution = (ShadowResolution)value;
    }

    public void PostProccesing_DropDown_OnChanged(int value)
    {
        // доделать
    }

    public void AntiAliasing_DropDown_OnChanged(int value)
    {
        Global_Settings.Init.antiAliasing = value;
    }
}

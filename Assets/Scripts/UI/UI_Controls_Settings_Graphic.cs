
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controls_Settings_Graphic : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown textures;
    [SerializeField] private TMP_Dropdown shadow;
    [SerializeField] private Toggle postProcessing;
    [SerializeField] private TMP_Dropdown antiAliasing;

    private void OnEnable()
    {
        textures.value = Global_Settings.InitOldValues.textureResolition;
        shadow.value = (int)Global_Settings.InitOldValues.shadowResolution;
        postProcessing.isOn = Global_Settings.InitOldValues.postProcessingEnabled;
        antiAliasing.value = Global_Settings.InitOldValues.antiAliasing;
    }

    public void Textures_DropDown_OnChanged(int value)
    {
        Global_Settings.Init.textureResolition = value;
    }

    public void Shadow_DropDown_OnChanged(int value)
    {
        Global_Settings.Init.shadowResolution = (ShadowResolution)value;
    }

    public void PostProccesing_Toggle_OnChanged(bool value)
    {
        Global_Settings.Init.postProcessingEnabled = value;
    }

    public void AntiAliasing_DropDown_OnChanged(int value)
    {
        Global_Settings.Init.antiAliasing = value;
    }
}

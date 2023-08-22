using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controls_Settings_Video : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolution;

    private void Start()
    {
        // б пекхге пюанрюер ме йнппейрмн!
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            string strResolution = $"{Screen.resolutions[i].width}x{Screen.resolutions[i].height}";
            resolution.options.Add(new TMP_Dropdown.OptionData(strResolution));

            if (Screen.resolutions[i].Equals(Screen.currentResolution)) resolution.value = i;
        }
    }

    public void Resolution_DropDown_OnChanged(int value)
    {
        var selected = Screen.resolutions[value];
        if(selected.Equals(Screen.currentResolution)) return;

        Screen.SetResolution(selected.width, selected.height, true);
        Global_Settings.Init.resolution = selected;
    }

    public void VSync_Toggle_OnChanged(bool value)
    {
        if(value) Global_Settings.Init.vsync = 1;
        else Global_Settings.Init.vsync = 0;
    }
}

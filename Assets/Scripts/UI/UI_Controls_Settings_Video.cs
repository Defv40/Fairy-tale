using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class UI_Controls_Settings_Video : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown tmp_resolution;
    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = (from r in Screen.resolutions where r.refreshRateRatio.Equals(Screen.currentResolution.refreshRateRatio) select r).ToArray();

        int i = -1;
        while (++i < resolutions.Length)
        {
            var str = $"{resolutions[i].width}x{resolutions[i].height}";
            tmp_resolution.options.Add(new TMP_Dropdown.OptionData(str));

            if (resolutions[i].Equals(Screen.currentResolution)) 
                tmp_resolution.value = i;
        }
    }

    public void Resolution_DropDown_OnChanged(int value)
    {
        var selected = resolutions[value];
        if (selected.Equals(Screen.currentResolution)) return;

        Screen.SetResolution(selected.width, selected.height, true);
        Global_Settings.Init.resolution = selected;
    }

    public void VSync_Toggle_OnChanged(bool value)
    {
        if (value) Global_Settings.Init.vsync = 1;
        else Global_Settings.Init.vsync = 0;
    }
}

using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controls_Settings_Video : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolution;
    [SerializeField] private Toggle vsync;
    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = (from r in Screen.resolutions where r.refreshRateRatio.Equals(Screen.currentResolution.refreshRateRatio) select r).ToArray();

        int i = -1;
        while (++i < resolutions.Length)
        {
            var str = $"{resolutions[i].width}x{resolutions[i].height}";
            resolution.options.Add(new TMP_Dropdown.OptionData(str));

            if (resolutions[i].Equals(Global_Settings.Init.resolution))
                resolution.value = i;
        }

        int vs = Global_Settings.Init.vsync;
        if (vs == 0) vsync.isOn = false;
        else vsync.isOn = true;
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

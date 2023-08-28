using System;
using System.IO;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Global_Settings : MonoBehaviour, ICloneable
{
    public static Global_Settings Init { get; private set; }
    public static Global_Settings InitOldValues { get; private set; }

    public PostProcessLayer postProcessLayer;
    public PostProcessVolume globalPostProcessVolume;

    public bool postProcessingEnabled;
    [Range(0, 2)] public int textureResolition;
    public ShadowResolution shadowResolution;
    //[Range(-1, 1)] public float brightness;
    [Range(0, 3)] public int antiAliasing;
    [Range(0, 4)] public int vsync;

    [Range(0, 1)] public float globalVolume;
    [Range(-80, 0)] public float musicVolume;
    [Range(-80, 0)] public float soundsVolume;

    public Resolution resolution;

    private ColorGrading globalColorGrading;

    private string pathSettings = Directory.GetCurrentDirectory() + "//" + "Settings.xml";

    private void OnGUI()
    {
        GUILayout.Label((1 / Time.unscaledDeltaTime).ToString());
    }

    private void OnEnable()
    {
        Init = this;

        resolution = Screen.currentResolution;
        Load();
        InitOldValues = (Global_Settings)Clone();
    }

    private void UpdateValues()
    {
        postProcessLayer.antialiasingMode = (PostProcessLayer.Antialiasing)antiAliasing;
        globalPostProcessVolume.profile.TryGetSettings(out globalColorGrading);
        //globalColorGrading.lift.value.w = brightness;

        if(shadowResolution == 0)
        {
            QualitySettings.shadows = ShadowQuality.Disable;
        }
        else
        {
            QualitySettings.shadows = ShadowQuality.All;
            QualitySettings.shadowResolution = shadowResolution;
        }
        QualitySettings.globalTextureMipmapLimit = textureResolition;
        QualitySettings.vSyncCount = vsync;
        globalPostProcessVolume.enabled = postProcessingEnabled;

        AudioListener.volume = globalVolume;
        SoundSystem.Instance.SetGlobalSettingsVolume(musicVolume, soundsVolume);
    }

    public void Save()
    {
        if (!resolution.Equals(Screen.currentResolution)) Screen.SetResolution(resolution.width, resolution.height, true);

        XDocument xSettings;
        xSettings = new XDocument();

        XElement xRoot = new XElement("settings");
        XElement xTextureResolution = new XElement("textureResolution", textureResolition.ToString());
        XElement xShadowResolution = new XElement("shadowResolution", shadowResolution.ToString());
        //XElement xBrightness = new XElement("brightness", brightness.ToString());
        XElement xAntiAliasing = new XElement("antiAliasing", antiAliasing.ToString());
        XElement xVsync = new XElement("vsync", vsync.ToString());
        XElement xPPEnabled = new XElement("postProcessing", postProcessingEnabled.ToString());

        XElement xGlobalVolume = new XElement("globalVolume", globalVolume.ToString());
        XElement xMusicVolume = new XElement("nusicVolume", musicVolume.ToString());
        XElement xSoundsVolume = new XElement("soundsVolume", soundsVolume.ToString());

        XElement xResolution = new XElement("resolution", $"{resolution.width}x{resolution.height}");

        xRoot.Add(xTextureResolution);
        xRoot.Add(xShadowResolution);
        //xRoot.Add(xBrightness);
        xRoot.Add(xAntiAliasing);
        xRoot.Add(xVsync);
        xRoot.Add(xPPEnabled);
        xRoot.Add(xGlobalVolume);
        xRoot.Add(xMusicVolume);
        xRoot.Add(xSoundsVolume);
        xRoot.Add(xResolution);
        xSettings.Add(xRoot);
        xSettings.Save(pathSettings);

        InitOldValues = (Global_Settings)Clone();
        UpdateValues();
    }

    public void Load()
    {
        try
        {
            XDocument xSettings;
            if (File.Exists(pathSettings))
            {
                xSettings = XDocument.Load(pathSettings);
                XElement xRoot = xSettings.Element("settings");
                textureResolition = int.Parse(xRoot.Element("textureResolution").Value);
                shadowResolution = (ShadowResolution)Enum.Parse(typeof(ShadowResolution), xRoot.Element("shadowResolution").Value);
                //brightness = float.Parse(xRoot.Element("brightness").Value);
                antiAliasing = int.Parse(xRoot.Element("antiAliasing").Value);
                vsync = int.Parse(xRoot.Element("vsync").Value);
                postProcessingEnabled = bool.Parse(xRoot.Element("postProcessing").Value);

                globalVolume = float.Parse(xRoot.Element("globalVolume").Value);
                musicVolume = float.Parse(xRoot.Element("nusicVolume").Value);
                soundsVolume = float.Parse(xRoot.Element("soundsVolume").Value);

                var strResolution = xRoot.Element("resolution").Value.Split('x');
                resolution.width = int.Parse(strResolution[0]);
                resolution.height = int.Parse(strResolution[1]);
            }
            else Save();
        }
        catch
        {
            Save();
        }

        UpdateValues();
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}

using System;

using System.IO;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Global_Settings : MonoBehaviour
{
    public static Global_Settings Init { get; private set; }

    public PostProcessLayer postProcessLayer;
    public PostProcessVolume globalPostProcessVolume;

    [Range(0, 2)] public int textureResolition;
    public ShadowResolution shadowResolution;
    [Range(-1, 1)] public float brightness;
    [Range(0, 3)] public int antiAliasing;
    [Range(0, 4)] public int vsync;

    [Range(0, 1)] public float globalVolume;
    [Range(0, 1)] public float musicVolume; // пока не используется
    [Range(0, 1)] public float soundsVolume; // пока не используется

    public Resolution resolution;

    private ColorGrading globalColorGrading;

    private string pathSettings = Directory.GetCurrentDirectory() + "//" + "Settings.xml";

    private void OnGUI()
    {
        GUILayout.Label((1 / Time.unscaledDeltaTime).ToString());
    }

    private void Awake()
    {
        Init = this;
        DontDestroyOnLoad(gameObject);

        if (resolution.width == 0 || resolution.height == 0) resolution = Screen.currentResolution;
        Load();
    }

    private void UpdateValues()
    {
        postProcessLayer.antialiasingMode = (PostProcessLayer.Antialiasing)antiAliasing;
        globalPostProcessVolume.profile.TryGetSettings(out globalColorGrading);
        globalColorGrading.lift.value.w = brightness;

        QualitySettings.shadowResolution = shadowResolution;
        QualitySettings.globalTextureMipmapLimit = textureResolition;
        QualitySettings.vSyncCount = vsync;

        AudioListener.volume = globalVolume;
    }

    public void Save()
    {
        UpdateValues();

        if (!resolution.Equals(Screen.currentResolution)) Screen.SetResolution(resolution.width, resolution.height, true);

        XDocument xSettings;
        //if (File.Exists(pathSettings)) xSettings = XDocument.Load(pathSettings);
        //else
        xSettings = new XDocument();

        XElement xRoot = new XElement("settings");
        XElement xTextureResolution = new XElement("textureResolution", textureResolition.ToString());
        XElement xShadowResolution = new XElement("shadowResolution", shadowResolution.ToString());
        XElement xBrightness = new XElement("brightness", brightness.ToString());
        XElement xAntiAliasing = new XElement("antiAliasing", antiAliasing.ToString());
        XElement xVsync = new XElement("vsync", vsync.ToString());

        XElement xGlobalVolume = new XElement("globalVolume", globalVolume.ToString());
        XElement xMusicVolume = new XElement("nusicVolume", musicVolume.ToString());
        XElement xSoundsVolume = new XElement("soundsVolume", soundsVolume.ToString());

        XElement xResolution = new XElement("resolution", $"{resolution.width}x{resolution.height}");

        xRoot.Add(xTextureResolution);
        xRoot.Add(xShadowResolution);
        xRoot.Add(xBrightness);
        xRoot.Add(xAntiAliasing);
        xRoot.Add(xVsync);
        xRoot.Add(xGlobalVolume);
        xRoot.Add(xMusicVolume);
        xRoot.Add(xSoundsVolume);
        xRoot.Add(xResolution);
        xSettings.Add(xRoot);
        xSettings.Save(pathSettings);
    }

    public void Load()
    {
        XDocument xSettings;
        if (File.Exists(pathSettings))
        {
            xSettings = XDocument.Load(pathSettings);
            XElement xRoot = xSettings.Element("settings");
            textureResolition = int.Parse(xRoot.Element("textureResolution").Value);
            shadowResolution = (ShadowResolution)Enum.Parse(typeof(ShadowResolution), xRoot.Element("shadowResolution").Value);
            brightness = float.Parse(xRoot.Element("brightness").Value);
            antiAliasing = int.Parse(xRoot.Element("antiAliasing").Value);
            vsync = int.Parse(xRoot.Element("vsync").Value);

            globalVolume = float.Parse(xRoot.Element("globalVolume").Value);
            musicVolume = float.Parse(xRoot.Element("nusicVolume").Value);
            soundsVolume = float.Parse(xRoot.Element("soundsVolume").Value);

            var strResolution = xRoot.Element("resolution").Value.Split('x');
            resolution.width = int.Parse(strResolution[0]);
            resolution.height = int.Parse(strResolution[1]);
        }
        else Save();
        

        UpdateValues();
    }
}


using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SoundSystem : MonoBehaviour
{
    

    private AudioSource _audioSource => GetComponent<AudioSource>();
    public AudioMixer Mixer;

    public static SoundSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null) Debug.LogError("Больше одного аудиоМенеджера");
        Instance = this;
    }
    public void PlaySound(AudioClip clip, float volume = 1f, bool destroyed = false, float p1= 0.85f, float p2 = 1.2f)
    {
        _audioSource.pitch = Random.Range(p1, p2);
        _audioSource.PlayOneShot(clip, volume);
    }

    /// <summary>
    /// Меняет громкость звуков в игре
    /// </summary>
    /// <param name="backGroundMusic">где 1 - это 100% громкость</param>
    /// <param name="soundMusic">где 1 - это 100% громкость</param>
    public void SetGlobalSettingsVolume()
    {
        float backGroundMusic = -10f; float soundMusic = -10f;
        Mixer.SetFloat("BackGroundMusicVolume", backGroundMusic);
        Mixer.SetFloat("SoundsVolume", soundMusic);
    }
}

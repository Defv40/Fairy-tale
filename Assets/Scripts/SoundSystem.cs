
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSystem : MonoBehaviour
{
    

    private AudioSource _audioSource => GetComponent<AudioSource>();

  
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
}

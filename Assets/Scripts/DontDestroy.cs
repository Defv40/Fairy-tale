using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] private AudioClip[] _musics;
    //[SerializeField] private bool _initMainMenuSound = false;
    //[SerializeField] private bool _initSecondBackgroundMusic = false;
    [SerializeField] private AudioSource _audioSource;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2)
        {
            _audioSource.clip = _musics[1];
            _audioSource.volume = 1f;
            _audioSource.Play();
        } 
    }
    private void Awake()
    {

        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
      
        DontDestroyOnLoad(gameObject);
        
    }
}

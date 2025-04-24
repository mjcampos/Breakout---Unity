using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance;
    
    [SerializeField] string[] scenesToStopMusic;
    
    
    AudioSource _audioSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!_audioSource)
        {
            return;
        }
        
        foreach (string sceneName in scenesToStopMusic)
        {
            if (scene.name == sceneName)
            {
                _audioSource.Stop();
                return;
            }
        }

        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

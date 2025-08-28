using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {
    public static AudioManager Instance;

    public float Volume
    {
        get => _audioSource.volume;
        set => _audioSource.volume = value;
    }
    
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
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        Volume = _audioSource.volume;
    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour {
    [SerializeField] Scrollbar scrollbar;
    
    AudioManager _audioManager;
    AudioSource _audioSource;

    void Start()
    {
        _audioManager = FindFirstObjectByType<AudioManager>();

        scrollbar.interactable = _audioManager;

        if (_audioManager)
        {
            _audioSource = _audioManager.GetComponent<AudioSource>();
            scrollbar.value = _audioSource.volume;
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void AdjustVolume()
    {
        _audioSource.volume = scrollbar.value;
    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour {
    [SerializeField] Scrollbar scrollbar;

    void Start()
    {
        scrollbar.value = AudioManager.Instance.Volume;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void AdjustVolume()
    {
        AudioManager.Instance.SetVolume(scrollbar.value);
    }

    public void ResetHighScore()
    {
        GameDataManager.Instance.ResetHighScore();
    }
}

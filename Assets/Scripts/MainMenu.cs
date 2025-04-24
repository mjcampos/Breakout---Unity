using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    [SerializeField] TextMeshProUGUI highScoreText;

    void Start()
    {
        UpdateHighScoreDisplay();
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToSettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }

    void UpdateHighScoreDisplay()
    {
        highScoreText.text = "High Score: " + GameDataManager.Instance.GetHighScore().ToString();
    }
}

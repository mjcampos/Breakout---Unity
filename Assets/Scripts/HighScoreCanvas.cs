using TMPro;
using UnityEngine;

public class HighScoreCanvas : MonoBehaviour {
    [SerializeField] TextMeshProUGUI highScoreText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateHighScoreText();
    }

    public void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + GameDataManager.Instance.GetHighScore().ToString();
    }
}

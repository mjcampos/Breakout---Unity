using TMPro;
using UnityEngine;

public class ScoreCanvas : MonoBehaviour {
    [SerializeField] TextMeshProUGUI scoreText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        scoreText.text = "000";
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString("D3");
    }
}

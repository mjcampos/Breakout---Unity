using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager Instance { get; private set; }
    
    int _score = 0;
    ScoreCanvas _scoreCanvas;

    void Awake()
    {
        // Singleton logic
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);  // only keep one instance
            return;
        }
        
        Instance = this;
    }

    void Start()
    {
        _scoreCanvas = FindFirstObjectByType<ScoreCanvas>();
    }

    public void SetScore(int score)
    {
        _score += score;
        _scoreCanvas.UpdateScore(_score);
    }
}

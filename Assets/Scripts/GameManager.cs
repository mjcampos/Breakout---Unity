using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    
    Ball _ball;
    Player _player;
    CountdownCanvas _countdownCanvas;

    void Awake()
    {
        // Enforce singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }
    
    /*
     * When the game begins perform the following steps:
     * 1. Freeze player and ball. It most likely is already frozen but won't hurt to double check
     * 2. Initiate countdown
     * 3. Wait for countdown to complete
     * 4. Unfreeze player and ball
     */

    void Start()
    {
        _ball = FindFirstObjectByType<Ball>();
        _player = FindFirstObjectByType<Player>();
        _countdownCanvas = FindFirstObjectByType<CountdownCanvas>();
        
        // Step 1
        if (_ball)
        {
            _ball.GameFirstLoaded();
        }

        if (_player)
        {
            _player.GameFirstLoaded();
        }
        
        // Step 2
        _countdownCanvas.StartCountdown();
    }

    // Step 3
    // Waiting for countdown to end
    public void CountdownEnded()
    {
        // Step 4
        
        // Unfreeze ball
        _ball.Unfreeze();
        
        // Unfreeze player
        _player.Unfreeze();
    }
}

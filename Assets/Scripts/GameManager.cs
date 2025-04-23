using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    
    Ball _ball;
    Player _player;
    CountdownCanvas _countdownCanvas;
    GameWonCanvas _gameWonCanvas;
    bool _playerHasRestartOption = false;

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
        _gameWonCanvas = FindFirstObjectByType<GameWonCanvas>();
        
        // Step 1
        if (_ball)
        {
            _ball.ResetBall();
        }

        if (_player)
        {
            _player.ResetPlayer();
        }
        
        // Step 2
        _countdownCanvas.StartCountdown();
    }

    void Update()
    {
        if (_playerHasRestartOption)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    // Step 3
    // Waiting for countdown to end
    public void CountdownEnded()
    {
        // Step 4
        
        // Unfreeze ball
        _ball.Unfreeze();
        
        // Unpause player
        _player.PausePlayer(false);
    }

    /*
     * When the ball hits the dead zone it is no longer playable and we need to reset its location
     * Perform the following steps in order:
     * 1. Pause game
     *      a. Pause the player movement and reset player to starting position
     *      b. Reset ball's position to starting point and stop its movement
     * 2. Start countdown
     * 3. Let player move
     * 4. Launch ball
     */
    public void BallHitsDeadZone() {
        // Step 1 - a
        _player.ResetPlayer();
        
        // Step 1 - b
        _ball.ResetBall();
        
        // Step 2
        _countdownCanvas.StartCountdown();
        
        /*
         * Step 3 - 4 : Performed in CountdownEnded,
         *  which is called in the countdown canvas at the end of the countdown
         */
    }

    public void PlayerWonGame() {
        /*
         * If number of bricks reaches 0 perform the following sequence:
         * 1. Freeze player
         * 2. Freeze ball
         * 3. Notify user that they won
         * 4. Give them the chance to restart the game
         */
        
        // Step 1
        _player.PausePlayer(true);
        
        // Step 2
        _ball.Freeze();
        
        // Step 3
        _gameWonCanvas.ShowGameWonText();
        
        // Step 4
        _playerHasRestartOption = true;
    }
}

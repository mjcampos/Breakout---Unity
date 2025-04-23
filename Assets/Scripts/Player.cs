using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    [SerializeField] float moveSpeed = 25f;

    Rigidbody2D _rigidbody2D;
    float _moveInput;
    bool _isPaused = true;
    Vector2 _startingPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _startingPosition = new Vector2(0, -15f);
        
        GameFirstLoaded();
    }

    public void GameFirstLoaded() {
        // Set pause to true to keep paddle from moving
        _isPaused = true;
        
        // Set paddle to starting point
        transform.position = _startingPosition;
    }

    public void Unfreeze()
    {
        _isPaused = false;
    }

    void OnMove(InputValue inputValue) {
        _moveInput = inputValue.Get<Vector2>().x;
    }

    void FixedUpdate()
    {
        Vector2 direction = Vector2.right * _moveInput;
        Vector2 velocity = direction * moveSpeed;
        
        _rigidbody2D.linearVelocity = _isPaused ? Vector2.zero : velocity;
    }
}

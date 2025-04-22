using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    [SerializeField] float moveSpeed = 25f;

    Rigidbody2D _rigidbody2D;
    float _moveInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue inputValue) {
        _moveInput = inputValue.Get<Vector2>().x;
    }

    void FixedUpdate()
    {
        Vector2 direction = Vector2.right * _moveInput;
        Vector2 velocity = direction * moveSpeed;
        
        _rigidbody2D.linearVelocity = velocity;
    }
}

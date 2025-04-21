using System;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D _rigidbody2D;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float input = Input.GetAxisRaw("Horizontal");
        Vector2 direction = Vector2.right * input;
        Vector2 velocity = direction * moveSpeed;
        Vector2 newPosition = velocity + _rigidbody2D.position;
        
        _rigidbody2D.MovePosition(newPosition);
    }
}

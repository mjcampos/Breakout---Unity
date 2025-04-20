using System;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float moveSpeed = 30f;

    Rigidbody2D _rigidbody2D;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        
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

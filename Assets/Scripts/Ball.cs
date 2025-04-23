using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour {
    [SerializeField] bool isTesting = false;
    
    Rigidbody2D _rigidbody2D;
    AudioSource _audiosSource;
    Vector2 _startingPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audiosSource = GetComponent<AudioSource>();
        
        _startingPosition = Vector2.zero;
        
        ResetBall();
    }

    public void ResetBall() {
        // Set position to starting point
        transform.position = _startingPosition;
        
        // Stop it from moving, if it is moving
        if (_rigidbody2D) {
            _rigidbody2D.linearVelocity = Vector2.zero;
        }
    }

    public void Unfreeze() {
        // Launch ball
        LaunchBall();
    }

    void LaunchBall() {
        float launchForce = 800f;
        Vector2 direction = isTesting ? Vector2.up : new Vector2(Random.Range(-1f, 1f), 1f).normalized;
        
        _rigidbody2D.AddForce(direction * launchForce);
    }

    void OnCollisionEnter2D(Collision2D other) {
        _audiosSource.Play();
    }
}

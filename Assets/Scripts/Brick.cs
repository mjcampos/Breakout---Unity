using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] int points;
    
    Bricks _bricks;

    void Start() {
        _bricks = GetComponentInParent<Bricks>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        // Pass along points to score manager
        ScoreManager.Instance.SetScore(points);
        
        // Let its parent know that it lost a brick and pass along brick's location
        _bricks.BrickLost(transform.position);
        
        // Destroy brick
        Destroy(gameObject);
    }
}

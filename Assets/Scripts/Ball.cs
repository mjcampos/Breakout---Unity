using UnityEngine;

public class Ball : MonoBehaviour
{
    float _launchForce = 600f;
    Rigidbody2D _rigidbody2D;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        LaunchBall();
    }

    void LaunchBall()
    {
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), 1f).normalized;
        
        _rigidbody2D.AddForce(direction * _launchForce);
    }
}

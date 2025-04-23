using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] GameObject audioPrefab;
    
    Bricks _bricks;

    void Start() {
        _bricks = GetComponentInParent<Bricks>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        // Instantiate a temporary audio source at the brick's position
        GameObject tempAudio = Instantiate(audioPrefab, transform.position, Quaternion.identity);
        AudioSource audioSource = tempAudio.GetComponent<AudioSource>();

        audioSource.clip = explosionSound;
        audioSource.Play();
        
        // Destroy temp object after sound finishes
        Destroy(tempAudio, explosionSound.length);
        
        // Pass along points to score manager
        ScoreManager.Instance.SetScore(points);
        
        // Let its parent know that it lost a brick
        _bricks.BrickLost();
        
        // Destroy brick
        Destroy(gameObject);
    }
}

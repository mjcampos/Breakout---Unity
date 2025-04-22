using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] GameObject audioPrefab;

    void OnCollisionEnter2D(Collision2D other) {
        // Instantiate a temporary audio source at the brick's position
        GameObject tempAudio = Instantiate(audioPrefab, transform.position, Quaternion.identity);
        AudioSource audioSource = tempAudio.GetComponent<AudioSource>();

        audioSource.clip = explosionSound;
        audioSource.Play();
        
        // Destroy temp object after sound finishes
        Destroy(tempAudio, explosionSound.length);
        
        // Destroy brick
        Destroy(gameObject);
    }
}

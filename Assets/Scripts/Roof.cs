using System;
using UnityEngine;

public class Roof : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            // Notify the game manager to have the player paddle width shrunk
            GameManager.Instance.ShrinkPlayer();
        }
    }
}

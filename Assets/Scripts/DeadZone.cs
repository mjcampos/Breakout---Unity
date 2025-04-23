using System;
using System.Collections;
using UnityEngine;

public class DeadZone : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ball")) {
            StartCoroutine(HandleBallLoss());
        }
    }

    IEnumerator HandleBallLoss() {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.BallHitsDeadZone();
    }
}

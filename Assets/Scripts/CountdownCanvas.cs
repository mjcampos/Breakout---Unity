using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CountdownCanvas : MonoBehaviour {
    [SerializeField] TextMeshProUGUI countdownText;

    int _countdown = 3;

    void Start() {
        countdownText.text = "";
    }

    public void StartCountdown() {
        _countdown = 3;
        
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown() {
        yield return null;
        
        while (_countdown > 0) {
            countdownText.text = _countdown.ToString();
            yield return new WaitForSeconds(1f);
            _countdown--;
        }
        
        countdownText.text = _countdown.ToString();
        
        yield return new WaitForSeconds(0.5f);
        
        countdownText.text = "";
        
        // Notify game manager that countdown has ended
        GameManager.Instance.CountdownEnded();
    }
}

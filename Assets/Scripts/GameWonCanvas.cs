using TMPro;
using UnityEngine;

public class GameWonCanvas : MonoBehaviour {
    [SerializeField] TextMeshProUGUI gameWonText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        gameWonText.gameObject.SetActive(false);
    }

    public void ShowGameWonText() {
        gameWonText.gameObject.SetActive(true);
    }
}

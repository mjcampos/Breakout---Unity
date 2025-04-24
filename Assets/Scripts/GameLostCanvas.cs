using TMPro;
using UnityEngine;

public class GameLostCanvas : MonoBehaviour {
    [SerializeField] TextMeshProUGUI gameLostText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        gameLostText.gameObject.SetActive(false);
    }

    public void ShowGameLostText()
    {
        gameLostText.gameObject.SetActive(true);
    }
}

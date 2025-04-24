using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}

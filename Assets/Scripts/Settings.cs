using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

using UnityEngine;

public class HeartsCanvas : MonoBehaviour {
    [SerializeField] GameObject[] hearts;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetHearts();
    }

    public void ResetHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            GameObject heart = hearts[i];
            
            heart.SetActive(true);
        }
    }

    public void RemoveHeart()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            GameObject heart = hearts[i];

            if (heart.activeSelf)
            {
                heart.SetActive(false);
                return;
            }
        }
    }
}

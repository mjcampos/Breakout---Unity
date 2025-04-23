using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {
    [SerializeField] bool isTesting = false;
    [SerializeField] List<GameObject> testBricks = new List<GameObject>();
    
    int _numberOfBricks;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        if (isTesting) {
            for (int i = 0; i < transform.childCount; i++) {
                GameObject childObject = transform.GetChild(i).gameObject;

                if (!testBricks.Contains(childObject)) {
                    childObject.SetActive(false);
                }
            }
            
            _numberOfBricks = testBricks.Count;
        }
        else {
            _numberOfBricks = transform.childCount;
        }
    }

    public void BrickLost() {
        _numberOfBricks--;
        
        if (_numberOfBricks <= 0) {
            StartCoroutine(NotifyPlayerHasWon());
        }
    }

    IEnumerator NotifyPlayerHasWon() {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.PlayerWonGame();
    }
}

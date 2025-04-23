using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UISpriteAnimation : MonoBehaviour {
    [SerializeField] Sprite[] spriteArray;
    [SerializeField] float changeSpeed = .2f;
    
    Image _image;
    int _spriteArrayLength;

    void Start() {
        _image = GetComponent<Image>();
        _spriteArrayLength = spriteArray.Length;

        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation() {
        int currentSpriteIndex = 0;
        
        do {
            Sprite currentSprite = spriteArray[currentSpriteIndex];
            
            _image.sprite = currentSprite;
            
            yield return new WaitForSeconds(changeSpeed);
            
            currentSpriteIndex++;

            if (currentSpriteIndex >= _spriteArrayLength) {
                currentSpriteIndex = 0;
            }
        } while (true);
    }
}

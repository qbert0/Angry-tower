using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapImage : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    private bool isSwap;

    private void Start() {
        image.sprite = sprite1;
        isSwap = true;
    }

    public void Swap() {
        isSwap = !isSwap;
        if(isSwap) {
            image.sprite = sprite1;
        } else {
            image.sprite = sprite2;
        }
    }
    
}

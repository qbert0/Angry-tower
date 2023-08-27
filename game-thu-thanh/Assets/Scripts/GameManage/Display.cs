using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] TextMeshProUGUI SkipTime;
    [SerializeField] GameManager gameManager;

    float elapsedTime;


    private void Update() {
        UpdateTime();
        UpdateSkip();
    }

    private void UpdateTime() {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void UpdateSkip() {
        SkipTime.text = string.Format("x {0}", gameManager.gameOnly.GetI());
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioPage 
{
    public Action ClickBackButton {set => _backButton.clicked += value;}

    private Button _backButton;

    public AudioPage(VisualElement root) {
        _backButton = root.Q<Button>("back_button");

        addActionToButton();
    }

    public void addActionToButton() {
        // _backButton.clicked += () => BackAction();
    }

    private void BackAction() {
        // Time.timeScale = 1.0f;
    }
}

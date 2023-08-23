using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuPage 
{
    public Action ClickOptionsButton {set => _optionsButton.clicked += value; }
    public Action ClickStartButton {set => _startButton.clicked += value; }

    private Button _startButton;
    private Button _optionsButton;
    private Button _showMessage;

    public MenuPage(VisualElement root) {
        _startButton = root.Q<Button>("start_button");
        _optionsButton = root.Q<Button>("options_button");
        _showMessage = root.Q<Button>("exit_game_button");

        AddActionToButton();
    }


    private void AddActionToButton() {
        _startButton.clicked += () => Debug.Log("start");
        _optionsButton.clicked += () => Debug.Log("setting");
        _showMessage.clicked += () => Debug.Log("Show");
    }
}

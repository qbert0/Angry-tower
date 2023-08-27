using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameOverPage 
{

    public Action ClickVideoButton {set => _videoButton.clicked += value; }
    public Action ClickPlayagainButton{set => _playagainButton.clicked += value; }
    
    private Button _videoButton;
    private Button _playagainButton;
    private Button _homeButton;

    public GameOverPage (VisualElement root) {
        _videoButton = root.Q<Button>("video_button");
        _playagainButton = root.Q<Button>("play_again_button");
        _homeButton = root.Q<Button>("quit_button");

        AddActionToButton();

    }

    private void AddActionToButton () {
        _videoButton.clicked += () => Debug.Log("video");
        _playagainButton.clicked += () => Debug.Log("play again");
        _homeButton.clicked += () => Debug.Log("home");
    }
}

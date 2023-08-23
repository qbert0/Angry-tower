using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class OptionsPage 
{
    public Action ClickBackButton {set => _backButton.clicked += value; }
    public Action ClickAudioButton {set => _audioButton.clicked += value;}

    private Button _audioButton;
    private Button _documentButton;
    private Button _backButton;
    public OptionsPage(VisualElement root) {
        _audioButton = root.Q<Button>("audio_button");
        _documentButton = root.Q<Button>("document_button");
        _backButton = root.Q<Button>("back_button");

        AddActionToButton();
    }

    private void AddActionToButton() {
        _audioButton.clicked += () => Debug.Log("audio");
        _documentButton.clicked += () => Debug.Log("document");
        _backButton.clicked += () => Debug.Log("back");
    }
}

using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class GamePage 
{
   
    public Action ClickPauseButton {set => _pasueButton.clicked += value; }
    public Action ClickSettingButton {set => _settingButton.clicked += value; }
    public Action ClickSkipButton {set => _skipButton.clicked += value;}

    private Button _pasueButton;
    private Button _settingButton;
    private Button _skipButton;

    public GamePage (VisualElement root) {
        _pasueButton = root.Q<Button> ("pause_button");
        _settingButton = root.Q<Button>("setting_button");
        _skipButton = root.Q<Button>("skip_button");
        


        AddActionToButton();
    }

    private void AddActionToButton () {
        _pasueButton.clicked += () => PauseAction();
        _settingButton.clicked += () =>PauseAction();
        _skipButton.clicked += () =>SkipAction();
    }

    private void PauseAction () {
        Time.timeScale = 0f;
    }

    private void SkipAction () {
        
    }
 
}

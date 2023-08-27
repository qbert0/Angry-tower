using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PausePage
{
   public Action ClickResumeButton {set => _resumeButton.clicked += value;}
   public Action ClickRestartButton {set => _restartButton.clicked += value;}


   private Button _resumeButton;
   private Button _restartButton;
   private Button _homeButton;

   public PausePage(VisualElement root) {
        _resumeButton = root.Q<Button>("resume_button");
        _restartButton = root.Q<Button>("restart_button");
        _homeButton = root.Q<Button>("home_button");

        AddActionToButton();

   }

   private void AddActionToButton() {
    _resumeButton.clicked += () => Debug.Log("resume");
    _restartButton.clicked += () => Debug.Log("restart");
    _homeButton.clicked += () => Debug.Log("homebutton");
   }

   
}


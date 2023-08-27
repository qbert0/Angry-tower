using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOnly : MonoBehaviour
{

    [SerializeField] private float index;
    private float i;

    private VisualElement _gamePage;
    private VisualElement _pausePage;
    private VisualElement _audioPage;
    private VisualElement _gameOverPage;

    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _gamePage = root.Q("GamePage");
        _pausePage = root.Q("PauseMenu");
        _audioPage = root.Q("AudioPage");
        _gameOverPage = root.Q("GameOver");

        index = 3;
        i = 0;

        SetupGamePage();
        SetupPausePage();
        SetupAudioPage();
        SetupGameOverPage();
    }

    private void SetupGamePage() {
        GamePage gamePage= new GamePage(_gamePage);
        gamePage.ClickPauseButton = () => ToggleSwapPage(_pausePage,true);
        gamePage.ClickSettingButton = () => ToggleSwapPage(_audioPage,true);
        gamePage.ClickSkipButton = () => SetTime(1 + (++i) % index);
    }

    private void SetupPausePage() {
        PausePage pausePage = new PausePage(_pausePage);
        pausePage.ClickResumeButton = () => ToggleSwapPage(_pausePage,false);
        pausePage.ClickRestartButton = () => RestartGame();
    }

    private void SetupAudioPage() {
        AudioPage audioPage = new AudioPage(_audioPage);
        audioPage.ClickBackButton = () => ToggleSwapPage(_audioPage,false);
    }

    private void SetupGameOverPage() {
        GameOverPage gameOverPage = new GameOverPage(_gameOverPage);
        gameOverPage.ClickPlayagainButton = () => RestartGame();
        
    }

    private void SetTime(float time) {
        Time.timeScale = time;
    }


    private void ToggleSwapPage (VisualElement vs ,bool enable) {
        if(enable == false) {
            SetTime(1 + (i) % index);
        }
        Display(vs, enable);
    }

    private void Display(VisualElement element, bool enabled) {
        if (element == null) return;
        element.style.display = enabled ? DisplayStyle.Flex : DisplayStyle.None;
    }

    public float GetI() {
        return 1 + (i) % index;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SetI(0);
        SetTime(1 + (i) % index);

    }

    public void SetI(float i) {
        this.i = i;
    }

    public void GameOver () {
        _pausePage.style.display = DisplayStyle.None;
        _audioPage.style.display = DisplayStyle.None;
        
        Display(_gameOverPage,true);
        SetTime(0);
        Debug.Log("game over");
    }
}

using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class StartView : MonoBehaviour
{
    private VisualElement _optionsPage;
    private VisualElement _menuPage;
    private VisualElement _audioPage;

    private void Start() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _menuPage = root.Q("MenuPage");
        _optionsPage = root.Q("OptionsPage");
        _audioPage = root.Q("AudioPage");

        SetupStartPage();
        SetupOptionsPage();
        SetupAudioPage();
    }

    private void SetupStartPage() {
        MenuPage menuPage = new MenuPage(_menuPage);
        menuPage.ClickOptionsButton = () => ToggleSettingMenu(true);
        menuPage.ClickStartButton = () => StartGame();
    }

    private void SetupOptionsPage() {
        OptionsPage optionsPage = new OptionsPage(_optionsPage);
        optionsPage.ClickBackButton = () => ToggleSettingMenu(false);
        optionsPage.ClickAudioButton = () => ToggleAudio(true);
    }

    private void SetupAudioPage() {
        AudioPage audioPage= new AudioPage(_audioPage);
        audioPage.ClickBackButton = () => ToggleAudio(false);
    }


    private void ToggleSettingMenu(bool enable) {
        Display(_menuPage, !enable);
        Display(_optionsPage, enable);
        Debug.Log("options");
    }

    private void ToggleAudio(bool enable) {
        Display(_optionsPage, !enable);
        Display(_audioPage, enable);
        Debug.Log("audio");
    }

    private void Display(VisualElement element, bool enabled) {
        if (element == null) return;
        element.style.display = enabled ? DisplayStyle.Flex : DisplayStyle.None;
    }

    private void StartGame() {
        SceneManager.LoadScene("Game");
    }
    
    
}

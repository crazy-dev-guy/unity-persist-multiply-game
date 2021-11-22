using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour {

    public GameObject nameInputPanel;
    public GameObject mainMenuPanel;
    public GameObject nameDisplayPanel;
    public GameObject singlePlayerPanel;
    public GameObject multiplayerPanel;

    public Button nameInputConfirmButton;
    
    public Button musicButton;
    public Button soundButton;
    
    public Sprite toogleOn;
    public Sprite toogleOff;
    public TMP_InputField nameInputField;

    public TMP_Text singlePlayerRankLabel;
    public TMP_Text singlePlayerDifficultyLabel;
    public TMP_Text playerNameLabel;

    private GameStats gameStats;
    private SoundController soundController;

    
    
    void Start() {
        gameStats = GameObject.Find("GameStatsController").GetComponent<GameStats>();
        soundController = GameObject.Find("AudioSources").GetComponent<SoundController>();

        soundController.PlayMusicByIndex(0);

        if (gameStats.GetPlayerName() == null) {
            nameInputPanel.GetComponent<PanelFader>().Fade();
        } else {
            StartMainMenu();
        }

        // Gambiarra pra corrigir Sprites do Sound/Music enquanto não corrige a relação entre o 
        // singletom de AudioSources com o MainMenuController
        ToggleMusicFromSoundController();
        ToggleMusicFromSoundController();
        ToggleSoundFromSoundController();
        ToggleSoundFromSoundController();
    }

    void FixedUpdate() {
        if (nameInputField.text.Length > 3 && nameInputField.text.Length < 15) {
            nameInputConfirmButton.interactable = true;
        } else {
            nameInputConfirmButton.interactable = false;
        }
        
    }

    public void StartMainMenu() {
        nameInputConfirmButton.interactable = false;      
        nameInputPanel.GetComponent<PanelFader>().Fade();
        nameInputPanel.SetActive(false);
        

        mainMenuPanel.SetActive(true);
        StartCoroutine(Waiter(0.5f));
        
        if (gameStats.GetPlayerName() == null) gameStats.SetPlayerName(nameInputField.text);
        nameDisplayPanel.GetComponent<PanelFader>().Fade();
        playerNameLabel.SetText(gameStats.GetPlayerName());
        mainMenuPanel.GetComponent<PanelFader>().Fade();
    }
    
    public void ToggleSinglePlayerMenu() {
            mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
            singlePlayerPanel.SetActive(!singlePlayerPanel.activeSelf);
    }
    
    public void ToggleMultiplayerMenu() {
        
    }

    public void ChangeRank() {
        gameStats.ChangeRank();
        singlePlayerRankLabel.text = gameStats.GetRank();
    }
    
    public void ChangeDifficulty() {
        gameStats.ChangeDifficulty();
        singlePlayerDifficultyLabel.text = gameStats.GetDifficulty().GetName();
    }
    
    public void ExitGame() {
        Application.Quit();
    }

    public void StartSinglePlayer() {
        SceneManager.LoadScene("SinglePlayerGameScene");
    }

    public void PlaySoundByIndexFromSoundController(int index) {
        soundController.PlaySoundByIndex(index);
    }    
    public void ToggleMusicFromSoundController() {
        if (soundController.ToggleMusic()) {
            musicButton.GetComponent<Image>().sprite = toogleOn;
        } else {
            musicButton.GetComponent<Image>().sprite = toogleOff;
        }
    }
    public void ToggleSoundFromSoundController() {
        if (soundController.ToggleSound()) {
            soundButton.GetComponent<Image>().sprite = toogleOn;
        } else {
            soundButton.GetComponent<Image>().sprite = toogleOff;
        }
    }

    IEnumerator Waiter(float seconds){        
    yield return new WaitForSeconds(seconds);
    }
}

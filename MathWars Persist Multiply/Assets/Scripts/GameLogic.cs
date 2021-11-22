using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {
    [SerializeField] private int roundNumber = 1;
    [SerializeField] private int gamePoints = 0;
    [SerializeField] private GameObject playAgainBox = null;


    public GameObject playerLifePanel;
    public GameObject answerButtonsPanel;
    public GameObject lifePrefab;
    public GameObject answerButtonPrefab;

    
    public TMP_Text gameNameLabel;
    public TMP_Text roundTimerText;
    public TMP_Text gamePointsText;
    public TMP_Text roundNumberText;
    public TMP_Text operationText;


    public Sprite fullLifeImage;
    public Sprite lostLifeImage;
    
    private GameObject gameStatsController;
    private GameStats gameStats;
    private List<GameObject> lifeList = new List<GameObject>();
    private List<GameObject> answerButtonList = new List<GameObject>();

    
    private int lifesLeft;
    private int correctAnswer;
    
    private float roundTimer;
    private bool gameIsRunning = true;

    private SoundController soundController;    

    private void Awake()
    {
        gameStatsController = GameObject.Find("GameStatsController");
        
        soundController = GameObject.Find("AudioSources").GetComponent<SoundController>();

        soundController.PlayMusicByIndex(1);
        gameStats = gameStatsController.GetComponent<GameStats>();
        gameNameLabel.text = gameStats.GetPlayerName();

        NewGame();
    }
    private void Update()
    {
        if(gameIsRunning)
        {
            CalculateTimer();
        }
    }

    public void CalculateTimer()
    {
        roundTimer -= Time.deltaTime;
        roundTimerText.text = ((int)roundTimer).ToString();
        if (roundTimer <= 0.0f)
        {
            RoundLoss();
        }
    }

    private void RoundLoss()
    {
        lifeList[lifesLeft].GetComponent<Image>().sprite = lostLifeImage;
        lifesLeft--;
        if (lifesLeft >= 0)
        {
            NextRound();
        }else
        {
            GameOver();
        }
    }

    private void NextRound()
    {
        roundTimer = gameStats.GetDifficulty().GetTimePerRound();
        roundNumber += 1;
        roundNumberText.text = "Round: " + roundNumber.ToString();
        SetQuestionAndAnswers();
    }

    private void GameOver()
    {
        gameIsRunning = false;
        operationText.text = "You Lose";
        playAgainBox.SetActive(true);
    }

    private void CalculatePoints()
    {
        gamePoints += (int)roundTimer;
        gamePointsText.text = "Score: " + gamePoints.ToString();
    }

    private void SetQuestionAndAnswers()
    {
        correctAnswer = GetCorrectAnswer();
        List<int> listOfAnswers = GetAllAnswersList();

        GameUtils.Shuffle(listOfAnswers);

        for (int i = 0; i < listOfAnswers.Count; i++) {
            answerButtonList[i].GetComponentInChildren<TMP_Text>().text = listOfAnswers[i].ToString();
        }
    }

    private int GetCorrectAnswer()
    {
        return Random.Range(0, answerButtonList.Count);
    }

    private List<int> GetAllAnswersList()
    {
        List<int> answerList = new List<int>();

        answerList.Add(correctAnswer);

        while(answerList.Count < answerButtonList.Count) {
            int newWrongAnswer = Random.Range(0, 100);

            if (!answerList.Contains(newWrongAnswer)) {
                answerList.Add(newWrongAnswer);
            }
        }

        return answerList;
    }

    public void NewGame()
    {
        PopulateAnswerButtons();
        PopulatePlayerLives();
        SetQuestionAndAnswers();
        roundTimer = gameStats.GetDifficulty().GetTimePerRound();
        gamePoints = 0;
        gamePointsText.text = "Score: " + gamePoints.ToString();
        roundNumber = 1;
        roundNumberText.text = "Round: " + roundNumber.ToString();
        playAgainBox.SetActive(false);
        gameIsRunning = true;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    private void PopulatePlayerLives() {
        lifesLeft = gameStats.GetDifficulty().GetLifeNumber() - 1;
        if (lifeList.Count == 0) {
            for (int i = 0; i <= lifesLeft; i++) {
                GameObject life = Instantiate(lifePrefab) as GameObject;
                life.transform.SetParent(playerLifePanel.transform, false);
                lifeList.Add(life);
            }
        } else {
            foreach (GameObject life in lifeList) {
                life.GetComponent<Image>().sprite = fullLifeImage;
            }
        } 
    }

    private void PopulateAnswerButtons() {   
        if (answerButtonList.Count == 0) {
            for (int i = 0; i < gameStats.GetDifficulty().GetNumberOfAnswers(); i++) {
                GameObject newAnswerButton = Instantiate(answerButtonPrefab) as GameObject;
                newAnswerButton.transform.SetParent(answerButtonsPanel.transform, false);
                newAnswerButton.GetComponent<Button>().onClick.AddListener(delegate() { CheckAnswerButtonIsCorrect(newAnswerButton); });
                answerButtonList.Add(newAnswerButton);
            }
        }
    }

    public void CheckAnswerButtonIsCorrect(GameObject answerButton) {
        if (answerButton.GetComponentInChildren<TMP_Text>().text == correctAnswer.ToString()) {
            soundController.PlaySoundByIndex(2);
            CalculatePoints();
            NextRound();
        } else {
            soundController.PlaySoundByIndex(3);
            RoundLoss();
        }

    }

}

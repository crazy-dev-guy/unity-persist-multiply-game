using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour {
    public static GameStats Instance { get; private set; }

    private string playerName;

    private List<string> gameRanks = new List<string>{ 
            "Rookie", 
            "Professional"
        };
    
    private List<Difficulty> gameDifficulty = new List<Difficulty>{
            DifficultyList.EASY, 
            DifficultyList.MEDIUM, 
            DifficultyList.HARD, 
            DifficultyList.IMPOSSIBLE
        };
    
    private int currentRank = 0;
    private int currentDifficulty = 0;
    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public string GetRank() {
        return gameRanks[currentRank];
    }
    
    public Difficulty GetDifficulty() {
        return gameDifficulty[currentDifficulty];
    }

    public void ChangeRank() {
        currentRank++;
        if (currentRank == gameRanks.Count){
            currentRank = 0;
        }
    }
    
    public void ChangeDifficulty() {
        currentDifficulty++;
        if (currentDifficulty == gameDifficulty.Count){
            currentDifficulty = 0;
        }
    }

    public void SetPlayerName(string playerName) {
        this.playerName = playerName;
    }

    public string GetPlayerName() {
        return this.playerName;
    }

}

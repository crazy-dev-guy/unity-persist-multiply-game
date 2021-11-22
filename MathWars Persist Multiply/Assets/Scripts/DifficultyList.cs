public static class DifficultyList {

    public static Difficulty EASY = new Difficulty(
        "Easy", // Name
        5, // Life Number
        3, // Number Of Possible Answers
        30 // Time Per Round
    );
    
    public static Difficulty MEDIUM = new Difficulty(
        "Medium",
        4,
        3,
        20
    );

    public static Difficulty HARD = new Difficulty(
        "Hard",
        3,
        4,
        15
    );
    
    public static Difficulty IMPOSSIBLE = new Difficulty(
        "Impossible",
        2,
        5,
        10
    );
    
    
}

public class Difficulty {

    private string name;
    private int lifeNumber;
    private int numberOfAnswers;
    private int timePerRound;

    public Difficulty(string name, int lifeNumber, int numberOfAnswers, int timePerRound) {
        this.name = name;
        this.lifeNumber = lifeNumber;
        this.numberOfAnswers = numberOfAnswers;
        this.timePerRound = timePerRound;
    }

    public string GetName() {
        return this.name;
    }

    public int GetLifeNumber() {
        return this.lifeNumber;
    }
    
    public int GetNumberOfAnswers() {
        return this.numberOfAnswers;
    }
    
    public int GetTimePerRound() {
        return this.timePerRound;
    }
}

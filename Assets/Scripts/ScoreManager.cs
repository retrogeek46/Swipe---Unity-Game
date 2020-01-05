using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public LevelManager             lvlManager;         // reference to the levelManager component
    public static bool              isCorrect;          // static bool to check if user swiped in the correct direction 
    private int                     correctChoice;      // the correct direction for current scenario
    private int                     playerChoice;       // the direction that the player swiped in
    public static int               score;              // static int to keep track of the score
    public Text                     scoreBoard;         // reference to the textbox to show the score
    public Text                     highScoreBoard;     // reference to the textbox to show the highscore
    public Sprite[]                 hintSprites;        // array containing the prompts for the direction to swipe
    public Image                    hint;               // image to show for the current correct direction
    public static string            reason = "";        // reason for player death - timeout or wrong swipe (mainly for debugging)
    public int                      highScore;          // highscore of all time
    public static bool              newHighScore;       // bool to see if player has achieved a new highscore
    
    // Use this for initialization
	void Start () {
        newHighScore = false;
        highScore = PlayerPrefs.GetInt("high_score", 0);
        highScoreBoard.text = "HIGHSCORE : " + highScore;
        score = 0;
        scoreBoard.text = "SCORE : " + score;
        ChangeHint();
        lvlManager = GameObject.FindObjectOfType<LevelManager>();
        isCorrect = true;
	}
	
	// Update is called once per frame
	void Update () {
        // if player has swiped then move the cube
        if (RotateCube.doMove) {
            playerChoice = RotateCube.direction;
            // if player swiped in the correct direction
            if (playerChoice == correctChoice) {
                Debug.Log("Correct answer");
                TextureManager.doChange = true;
                ChangeHint();
                isCorrect = true;
                score++;
                // if highscore
                if (score >= highScore) {
                    highScore = score;
                    newHighScore = true;
                    highScoreBoard.text = "HIGHSCORE : " + highScore;
                }
                scoreBoard.text = "SCORE : " + score; 
            } 
            // if wrong direction
            else {
                isCorrect = false;
                reason = "Wrong Choice!";
                Debug.Log("Game Over");
            }
        }
        // check if wrong choice
        // TODO: maybe move this to a function
        if (!isCorrect) {
            Debug.Log("not correct");
            if (newHighScore) {
                PlayerPrefs.SetInt("high_score", highScore);
                PlayerPrefs.Save();
            }
            isCorrect = true;
            lvlManager.ChangeLevel("Lose_Screen");
        }
	}

    /// <summary>
    /// Function to change the current direction prompt by choosing a random direction
    /// </summary>
    public void ChangeHint() {
        correctChoice = UnityEngine.Random.Range(0, 4);
        hint.sprite = hintSprites[correctChoice];
    }
}

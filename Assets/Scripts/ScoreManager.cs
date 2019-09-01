using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public LevelManager lvlManager;
    public static bool isCorrect;
    private int correctChoice;
    private int playerChoice;
    public static int score;
    public Text scoreBoard;
    public Text highScoreBoard;
    public Sprite[] hintSprites;
    public Image hint;
    public static string reason = "";
    public int highScore;
    public static bool newHighScore;
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
        if (RotateCube.doMove) {
            playerChoice = RotateCube.direction;
            //Debug.Log("pc: " + playerChoice + ", cc: " + correctChoice);
            if (playerChoice == correctChoice) {
                Debug.Log("Correct answer");
                TextureManager.doChange = true;
                ChangeHint();
                isCorrect = true;
                score++;
                if (score >= highScore) {
                    highScore = score;
                    newHighScore = true;
                    highScoreBoard.text = "HIGHSCORE : " + highScore;
                }
                scoreBoard.text = "SCORE : " + score; 
            } else {
                isCorrect = false;
                
                reason = "Wrong Choice!";
                Debug.Log("Game Over");
            }
        }
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

    public void ChangeHint() {
        correctChoice = UnityEngine.Random.Range(0, 4);
        hint.sprite = hintSprites[correctChoice];
    }
}

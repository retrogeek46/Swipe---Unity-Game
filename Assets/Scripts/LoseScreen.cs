using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour {

    public Text         lossReason;         // textbox to show why the player lost (timeout or wrong swipe)
    public Text         yourScore;          // textbox to show the score
    public LevelManager lvlManager;         // reference to levelManager object
    public Image        highScoreImage;     // Image to show when achieving a highscore
    
    // Start is called before the first frame update
    void Start() {
        // if on loss scene then set textbox values
        if (SceneManager.GetActiveScene().name == "Lose_Screen") {
            yourScore.text = "You scored " + ScoreManager.score + " points.";
            lossReason.text = ScoreManager.reason;
            if (ScoreManager.newHighScore) {
                highScoreImage.enabled = true;
            } else {
                highScoreImage.enabled = false;
            }
        }
        // get reference to the LevelManager
        lvlManager = GameObject.FindObjectOfType<LevelManager>();
    }

    /// <summary>
    /// A wrapper function to call the actual change level function 
    /// </summary>
    /// <param name="level">Name of the level</param>
    public void ChangeLevelWrapper(string level) {
        lvlManager.ChangeLevel(level);
    }
}

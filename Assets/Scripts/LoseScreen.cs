using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour {

    public Text lossReason;
    public Text yourScore;
    public LevelManager lvlManager;
    public Image highScoreImage;
    
    // Start is called before the first frame update
    void Start() {
        if (SceneManager.GetActiveScene().name == "Lose_Screen") {
            yourScore.text = "You scored " + ScoreManager.score + " points.";
            lossReason.text = ScoreManager.reason;
            if (ScoreManager.newHighScore) {
                highScoreImage.enabled = true;
            } else {
                highScoreImage.enabled = false;
            }
        }
        lvlManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void ChangeLevelWrapper(string level) {
        lvlManager.ChangeLevel(level);
    }
}

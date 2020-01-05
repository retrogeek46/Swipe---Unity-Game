using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Slider timiLimitSlider;      // reference to the slider 
    public float  limit;                // the time limit
    public float  current;              // the current time
    public float  sliderValue;          // value of the slider based on current time and the time limit
    
    // Start is called before the first frame update
    void Start() {
        current = 0;
        sliderValue = 1;
        timiLimitSlider.value = 1;
    }

    // Update is called once per frame
    void Update() {
        if (current >= limit) {
            current = 0;
            ScoreManager.isCorrect = false;
            ScoreManager.reason = "Time is up!";
        }
        if (TextureManager.doChange && ScoreManager.isCorrect) {
            current = 0;
            //sliderValue = 1;
            if (limit >= 50) {
                limit -= 10;
            }
        }
        current++;
        sliderValue = 1f - (current / limit);
        timiLimitSlider.value = sliderValue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance = null;        // create singleton
    public AudioClip    bgMusic;                // audio clip to play as background music
    public AudioClip[]  swipe;                  // array of audio clips to play when swiping
    private AudioSource bgAS;                   //
    private AudioSource swipeAS;                // 

    // create a singleton
    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        // add audiosource and play background music
        bgAS = gameObject.AddComponent<AudioSource>();
        bgAS.clip = bgMusic;
        bgAS.loop = true;
        bgAS.Play();
        // add audiosource for swipe
        swipeAS = gameObject.AddComponent<AudioSource>();
        swipeAS.loop = false;
    }

    // Update is called once per frame
    void Update() {
        // play swipe sounds
        if (RotateCube.doMove) {
            int index = UnityEngine.Random.Range(0, 2);
            swipeAS.clip = swipe[index];
            swipeAS.Play();
        }
    }
}

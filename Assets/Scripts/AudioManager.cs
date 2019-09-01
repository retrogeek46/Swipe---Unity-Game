using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance = null;     //create singleton
    public AudioClip bgMusic;
    public AudioClip[] swipe;
    private AudioSource bgAS;
    private AudioSource swipeAS;

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
        bgAS = gameObject.AddComponent<AudioSource>();
        bgAS.clip = bgMusic;
        bgAS.loop = true;
        bgAS.Play();

        swipeAS = gameObject.AddComponent<AudioSource>();
        swipeAS.loop = false;
    }

    // Update is called once per frame
    void Update() {
        if (RotateCube.doMove) {
            int index = UnityEngine.Random.Range(0, 2);
            swipeAS.clip = swipe[index];
            swipeAS.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    /// <summary>
    /// Function to change scenes based on scene name
    /// </summary>
    /// <param name="lvlName">Name of scene to load</param>
    public void ChangeLevel (string lvlName) {
        SceneManager.LoadScene(lvlName);
    }
}

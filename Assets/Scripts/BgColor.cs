using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgColor : MonoBehaviour
{
    public Camera mainCamera;
    public Color[] bgCol;
    int index, current, limit;
    // Start is called before the first frame update
    void Start() {
        index = 0;
        current = 0;
        limit = 70;
    }

    // Update is called once per frame
    void Update() {
        //change bg color
        mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, bgCol[index], 0.01f);
        if (current == limit) {
            current = 0;
            index = (index + 1) % 3;
        }
        current++;
    }
}

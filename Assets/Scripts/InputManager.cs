using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

	private Vector2 startPos, endPos;
	float horizontal = 0, vertical = 0;
    public float swipeLimit = 200;
	public static bool stop;

	// Update is called once per frame
	void Update () {
        // rotate cube using keyboard
        if (Input.GetKeyDown(KeyCode.W)) {
            RotateCube.direction = 0;
            RotateCube.doMove = true;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            RotateCube.direction = 1;
            RotateCube.doMove = true;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            RotateCube.direction = 2;
            RotateCube.doMove = true;
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            RotateCube.direction = 3;
            RotateCube.doMove = true;
        }

        // record the coord of first touch to know in which direction swipe took place
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			startPos = Input.GetTouch(0).position;
			Debug.Log("start touch");
		}

        // rotate cube based on swipe direction
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
			endPos = Input.GetTouch(0).position;

			horizontal = startPos.x - endPos.x;
			vertical = startPos.y - endPos.y;
            Debug.Log(horizontal);

            if (Mathf.Abs(vertical) > swipeLimit || Mathf.Abs(horizontal) > swipeLimit) {
                if (vertical < 0 && Mathf.Abs(vertical) > Mathf.Abs(horizontal)) {
                    RotateCube.direction = 0;
                    Debug.Log("up");
                }
                if (horizontal > 0 && Mathf.Abs(horizontal) > Mathf.Abs(vertical)) {
                    RotateCube.direction = 1;
                    Debug.Log("left");
                }
                if (vertical > 0 && Mathf.Abs(vertical) > Mathf.Abs(horizontal)) {
                    RotateCube.direction = 2;
                    Debug.Log("down");
                }
                if (horizontal < 0 && Mathf.Abs(horizontal) > Mathf.Abs(vertical)) {
                    RotateCube.direction = 3;
                    Debug.Log("right");
                }
                RotateCube.doMove = true;
            }
		}

        // pause game based keyboard input, currently not in use
		if (Input.GetKeyDown(KeyCode.K)) {
			stop = true;
		}
		if (Input.GetKeyUp(KeyCode.K)) {
			stop = false;
		}
	}
}

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
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			startPos = Input.GetTouch(0).position;

			Debug.Log("start touch");
		}

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
		if (Input.GetKeyDown(KeyCode.K)) {
			stop = true;
		}
		if (Input.GetKeyUp(KeyCode.K)) {
			stop = false;
		}
	}
}

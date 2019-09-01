using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour {

	public static bool doMove;
	public static bool isMoving;
	public static int direction;            //direction - Up = 1, Left = 2, Down = 3, Right = 4
	public float sensitivity = 0.7f;
	// Use this for initialization
	void Start () {
		isMoving = false;
		doMove = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (doMove) {
			//Debug.Log("move is true");
			doMove = false;
			switch (direction) {
				case 0:
					StartCoroutine(Rotate(1, 0));
					break;
				case 1:
					StartCoroutine(Rotate(0, 1));
					break;
				case 2:
					StartCoroutine(Rotate(-1, 0));
					break;
				case 3:
					StartCoroutine(Rotate(0, -1));
					break;
			}
		}
	}

	IEnumerator Rotate(int xAngle, int yAngle) {
		isMoving = true;
		transform.rotation = Quaternion.identity;
		Quaternion finalRotation = transform.rotation * Quaternion.Euler((90 * xAngle), (90 * yAngle), 0);
		while(transform.rotation != finalRotation) { 
			transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, sensitivity);
			yield return new WaitForSeconds(0.01f);
		}
		isMoving = false;
        //if (ScoreManager.isCorrect == true) {
        //    TextureManager.doChange = true;
        //}
    }
}

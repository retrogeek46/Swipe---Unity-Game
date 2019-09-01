using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Rotate(int direction) {
		if (!RotateCube.isMoving) {
			RotateCube.direction = direction;
			RotateCube.doMove = true;
			//Debug.Log("rotating in " + direction);
		} else {
			Debug.Log("already moving");
		}
	}
}

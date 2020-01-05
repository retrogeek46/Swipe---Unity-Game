using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
	/// <summary>
	/// A wrapper to rotate the cube based on the direction
	/// </summary>
	/// <param name="direction">The direction to rotate in</param>
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

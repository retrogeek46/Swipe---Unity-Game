using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour {

    private bool isMoving;
    public float sensitivity = 0.7f;
    public int current, limit, index;
    public Color materialColor;

    void Start () {
        GetComponent<Renderer>().material.color = materialColor;
        current = 0;
        //limit = 100;
        isMoving = false;
        index = 0;
    }

    // Update is called once per frame
    void Update () {
        if (current >= limit) {
            current = 0;
            //UnityEngine.Random.InitState(current);
            int direction;
            int axis = UnityEngine.Random.Range(1, 3);
            if (UnityEngine.Random.Range(1, 3) % 2 == 0) {
                direction = 1;
            } else {
                direction = -1;
            }
            if (axis == 1) {
                StartCoroutine(Rotate(1 * direction, 0));
            } else {
                StartCoroutine(Rotate(0, 1 * direction));
            }
        }
        current++;
    }

    /// <summary>
	/// An enumerator to rotate the cube based on x and y direction (both take values -1, 0 or +1)
	/// </summary>
	/// <param name="x">rotate left (1) or right (-1)</param>
	/// <param name="y">rotate up   (1) and down (-1)</param>
	/// <returns></returns>
    IEnumerator Rotate (int xAngle, int yAngle) {
        //cube.transform.rotation = Quaternion.identity;
        Quaternion finalRotation = transform.rotation * Quaternion.Euler((90 * xAngle), (90 * yAngle), 0);
        while (transform.rotation != finalRotation) {
            transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, sensitivity);
            yield return new WaitForSeconds(0.01f);
        }
    }
}

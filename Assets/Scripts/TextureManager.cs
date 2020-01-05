using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureManager : MonoBehaviour {

    public GameObject   cube;                       // 
	public Texture2D[]  faceSprites;                // 
	public Renderer[]   faces;                      // 
    public static bool  doChange;                   // bool to check if textures/color are to be changed
    public static int[] faceValues = new int[6];    // array having the six cube faces
    public static int   frontFace = 0;              // 
    public static int   prevValue = 0;              // 

    private Renderer cubeRenderer;
    public Color[] col;
    int index;

	// Use this for initialization
	void Start () {
        index = UnityEngine.Random.Range(0, 7);
        cubeRenderer = gameObject.GetComponent<Renderer>();
        cubeRenderer.material.color = col[index];

        doChange = false;
        prevValue = 0;

	}
	
	// Update is called once per frame
	void Update () {
        // when swiping change the color of the material
        if (doChange) {
            doChange = false;
            int temp = UnityEngine.Random.Range(0, 7);
            bool generating = true;
            while (generating) {
                if (temp != index) {
                    index = temp;
                    generating = false;
                } else {
                    temp = UnityEngine.Random.Range(0, 7);
                }
            }
            cubeRenderer.material.color = col[index];
        }
	}

    /// <summary>
    /// Function to apply texture to the cube
    /// </summary>
	public void ApplyTexture() {
		for (int i = 1; i < 6; i++) {
            if (i == prevValue) {
                Debug.Log("Not changing face " + prevValue);
                continue;
            } else {
                int index = UnityEngine.Random.Range(0, 4);
                faces[i].material.SetTexture("_MainTex", faceSprites[index]);
                faceValues[i] = index;
            }
		}
	}
}

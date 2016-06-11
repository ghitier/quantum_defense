using UnityEngine;
using System.Collections;

public class CamSetting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float newHeight = 4.8f;
    	// If the camera is less than 8:4.8 (= 5:3) wide
    	 if (Screen.width / ((float)Screen.height) < 5f / 3f)
        	 newHeight = Screen.height / ((float)Screen.width) * 8;
     	this.GetComponent<Camera>().orthographicSize = newHeight / 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

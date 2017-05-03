using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStartup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 camPosition = Camera.main.GetComponent<Transform>().position;

		GetComponent<Transform>().position = new Vector3(camPosition.x, camPosition.y, GetComponent<Transform>().position.z);
	}

	public static void SetupPosition(float fwidth, float fheight, Canvas _canvas){
		_canvas.GetComponent<Transform>().position = new Vector3(0f + fwidth/5, 0f, 0f);
	}
}

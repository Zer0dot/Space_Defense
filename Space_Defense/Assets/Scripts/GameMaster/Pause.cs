using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {


	//This also pauses when the player tabs out or just loses app focus in any other way than pressing ESC
	void Update () {
		if (Cursor.lockState == CursorLockMode.Locked){//Checks if the user's mouse is locked to see if the user is currently focused on the application
			Time.timeScale = 1f;
		}else{
			Time.timeScale = 0f;
		}
	}
}

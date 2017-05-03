using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
	[SerializeField]private GameObject menuCanvas;
	[SerializeField]private Behaviour lockScript;

	void Start(){
		Cursor.lockState = CursorLockMode.Locked;
	}

	//This also pauses when the player tabs out or just loses app focus in any other way than pressing ESC
	void Update () {
		if (Input.GetButtonDown("Pause")){
			if (Time.timeScale == 1f){
				Time.timeScale = 0f;
				menuCanvas.SetActive(true);
				lockScript.enabled = false;
				Cursor.lockState = CursorLockMode.None;
			}else{
				Time.timeScale = 1f;
				menuCanvas.SetActive(false);
				lockScript.enabled = true;
				Cursor.lockState = CursorLockMode.Locked;
				Debug.Log("lel");

			}
				
		}
	}
}

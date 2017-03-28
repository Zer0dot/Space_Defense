using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseConfine : MonoBehaviour {
	
	void Update () {
		if (Cursor.lockState == CursorLockMode.None){
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}

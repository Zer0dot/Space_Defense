using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMouse : MonoBehaviour {
	void Update(){
		if (Cursor.lockState == CursorLockMode.None){
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}

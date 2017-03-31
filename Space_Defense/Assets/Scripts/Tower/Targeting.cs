using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour {


	//Will make dynamic target acquisition, note that the tower MUST fire before changing targets at least once, but it might work otherwise.
	[SerializeField]private Transform tempTarget;

	void Start(){
		tempTarget = GameObject.FindWithTag("Player").transform;
	}

	void Update () {
		transform.LookAt(tempTarget);
	}
}

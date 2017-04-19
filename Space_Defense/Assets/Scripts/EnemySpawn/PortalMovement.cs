using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMovement : MonoBehaviour {

	private Transform player;
	[SerializeField]private float rotationIncrement = 0.2f;

	void Start(){
		player = GameObject.FindWithTag("Player").transform;
		transform.LookAt(player.position);
	}

	void Update(){
		transform.Rotate(-rotationIncrement*Vector3.forward*Time.deltaTime);//Portal rotation effect
	}
}

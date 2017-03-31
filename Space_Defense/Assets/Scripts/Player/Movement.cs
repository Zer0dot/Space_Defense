using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

	[SerializeField]private float basicSpeed;//Default movement speed
	private float jetSpeed;//"Jet" speed (sprint)
	private Rigidbody rb;//Rigidbody attached to this object

	//Initial setup
	void Start(){
		rb = GetComponent<Rigidbody>();
		jetSpeed = 2.0f*basicSpeed;
	}



	void Move(){
		//Note that GetAxis applies smoothing on its own, GetAxisRaw does not.
		//Input names have been altered for clarity, e.g: "Jump" is now "Vertical" and "Vertical" is now "Forwards"
		float horizontalValue = Input.GetAxis("Horizontal"); //Value between -1 and 1, -1 is left and 1 is right
		float forwardValue = Input.GetAxis("Forwards"); //Value between -1 and 1, -1 is backwards, 1 is forwards
		float verticalValue = Input.GetAxis("Vertical"); //Value between -1
		//Note that the vertical input axis is used for forwards, not actual elevation.(forwardValue)

		float speedModifier = basicSpeed;//Initialize speed modifier to the default speed value

		if (Input.GetButton("Jet")){//If the "Jet" button is held, speed is increased (jet defined in Input manager as LEFT SHIFT)
			speedModifier = jetSpeed;
		}

		rb.velocity = speedModifier*(transform.forward*forwardValue + transform.right*horizontalValue + transform.up*verticalValue);//Creates velocity vector using local direction vector addition
	}

	void Update(){
		Move();
	}
}

﻿using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	[SerializeField]private Material lineMaterial;
	[SerializeField]private Transform shotStartPosition;//muzzle of the gun
	[SerializeField]private float trailDuration = 0.1f;
	[SerializeField]private float spreadRadius;
	[SerializeField]private float range;
	[SerializeField]private float fireCooldown;

	private bool canFire = true;

	void FixedUpdate () {
		if (Input.GetButton("Fire1") && canFire ){
			//Ray for center of the screen used from mouseposition
			Ray visualRay = Camera.main.ScreenPointToRay (Input.mousePosition + new Vector3 (Random.Range (-spreadRadius, spreadRadius), Random.Range (-spreadRadius, spreadRadius), 0f));

			//Need physics Raycast using visualRay to determine whether there has been a hit
			RaycastHit hit; 
			bool hasHit = Physics.Raycast(visualRay, out hit, range);

			if (hasHit){
				DrawLine(shotStartPosition.position, hit.point, lineMaterial, trailDuration);
			}
			else{
				DrawLine(shotStartPosition.position, visualRay.direction*range + transform.position, lineMaterial, trailDuration);
			}

			canFire = false;
			StartCoroutine(ResetCooldown());
		}
	}


	private IEnumerator ResetCooldown(){
		yield return new WaitForSeconds(fireCooldown);
		canFire = true;
		
	}
	//Following function found through Answers, adapted to fit code and currently analyzing
	//Sort of a "IT WORKS SO IT'S OK" situation right now 
	void DrawLine(Vector3 start, Vector3 end, Material _lineMaterial, float duration = 0.2f){
		GameObject line = new GameObject();
		line.transform.SetParent(transform);
		line.transform.position = Vector3.zero;


		line.AddComponent<LineRenderer>();
		LineRenderer lr = line.GetComponent<LineRenderer>();
		lr.material = _lineMaterial;

		lr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

		lr.useWorldSpace = false;

		//lr.startColor = color; Removed, using material settings instead
		//lr.endColor = color; Removed, using material settings instead

		lr.startWidth = 0.05f;
		lr.endWidth = 0.05f;

		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
		GameObject.Destroy(line, duration);
	}
}

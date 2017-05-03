using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamParallax : MonoBehaviour {

	[SerializeField]private float limitx = 8f;
	[SerializeField]private float limity = 5f;

	[SerializeField]private Canvas menu;

	float parallaxValueX = 0.0f;
	float parallaxValueY = 0.0f;
	float distance = 0f;//Distance to UI to calculate frustum dimensions
	float frustumHeight = 0f;//height of frustum	
	float frustumWidth = 0f;//width of frustum

	void Start () {
		//Calculating frustum dimensions

	}
	

	void Update () {

		//Fix canvas position
		distance = Mathf.Abs(Camera.main.transform.position.z);
		frustumHeight = 2.0f * distance * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
		frustumWidth = frustumHeight * Camera.main.aspect;
		CanvasStartup.SetupPosition(frustumWidth, frustumHeight, menu);


		//Parallax effect
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10;
		Vector3 worldMousePoint = Camera.main.ScreenToWorldPoint(mousePos);

		float _frustumHeight = 2.0f * 10f * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
		float _frustumWidth = _frustumHeight * Camera.main.aspect;

		limitx = _frustumWidth/2;
		limity = _frustumHeight/2;

		parallaxValueX = Mathf.Clamp(0.5f*worldMousePoint.x, -limitx, limitx);
		parallaxValueY = Mathf.Clamp(0.5f*worldMousePoint.y, -limity, limity);

		transform.position = new Vector3(parallaxValueX, parallaxValueY, transform.position.z);

		Debug.Log(Camera.main.ScreenToWorldPoint(mousePos));
	}
}

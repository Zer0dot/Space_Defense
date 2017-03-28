using UnityEngine;
using System.Collections;

public class SimpleShoot : MonoBehaviour {
	[SerializeField]GameObject explosion;


	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition + new Vector3 (Random.Range (-7f, 7f), Random.Range (-7f, 7f), Random.Range (-7f, 7f)));
			//Collision
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				GameObject createdExplosion = Instantiate (explosion, hit.point, Quaternion.identity) as GameObject;
				createdExplosion.SetActive (true);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AlienPathing))]
public class AlienFire : MonoBehaviour {
	[SerializeField]private float fireInterval = 2f;
	[SerializeField]private float distanceToFire = 25f;
	[SerializeField]private Transform projectilePrefab;

	private AlienPathing pathScript;


	// Use this for initialization
	void Start () {
		pathScript = gameObject.GetComponent<AlienPathing>();
		StartCoroutine(Fire());
	}

	private IEnumerator Fire(){
		while (true){
			yield return new WaitForSeconds(fireInterval);
			if (pathScript.target = pathScript.player){
				if (projectilePrefab != null){
					Instantiate(projectilePrefab, transform.position, transform.rotation);
				}
			}
		}
	}
}

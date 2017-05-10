using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
	//collision ignoring is in other script
	[SerializeField]private float forceMod = 10000f;
	[SerializeField]private int shotDamage= 5;

	//On creation of projectile
	void Start () {
		GetComponent<Rigidbody>().AddForce(forceMod*transform.forward, ForceMode.Impulse);
	}

	//Uppon collision with either player, turret or core
	void OnTriggerEnter(Collider other){

		//Block detects collider and acts accordingly
		if (other.gameObject.tag == "Player"){
			
			PlayerMain.EditHealth("damage", shotDamage);
			Debug.Log(PlayerMain.health + " HP");
			Destroy(gameObject);

		}else if (other.gameObject.tag == "Turret"){
			
			other.gameObject.GetComponent<TowerMain>().EditTurretHealth("damage", shotDamage);

		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Creates tower after checking if there is space, must apply other constrictions later
public class CreateTower : MonoBehaviour {

	private Transform player;//The player Transform
	private Vector3 position;//The position where the player is trying to create a tower
	//private Collider[] obstructions;//Array of colliders at the given position

	[SerializeField]private float distance;//Distance from the player to select the position and spawn a tower if possible
	[SerializeField]private GameObject towerPrefab; //The tower prefab to instantiate
	[SerializeField]private float cost = 30f;

	void Start(){
		player = GameObject.FindWithTag("Player").transform;//Gets player transform
	}

	void Update(){
		if (Input.GetButtonUp("CreateTower") && PlayerMain.money >= cost){//CreateTower is defined as "f" in Input Manager
			
			position = distance*player.forward + player.position;
			Debug.Log(position);

			Collider[] obstructions = Physics.OverlapSphere(position, 1f); //Array of colliders at the given position with a given radius

			if (obstructions.Length == 0){
				Debug.Log("Unobstructed");
				Instantiate(towerPrefab, position, Quaternion.identity);
				PlayerMain.EditMoney("substract", cost);
			}


		}
	}


}

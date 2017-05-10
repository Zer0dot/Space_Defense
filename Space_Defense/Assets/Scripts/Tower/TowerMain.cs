using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMain : MonoBehaviour {

	[SerializeField]private int towerHealth = 100;

	//method to edit turret's health
	public void EditTurretHealth(string setting, int quantity){
		if (setting == "heal"){
			towerHealth += quantity;
		}else if (setting == "damage"){
			towerHealth -= quantity;
		}


		if (towerHealth <= 0){
			turretDeath();
		}
	}

	//method to call upon turret destruction
	void turretDeath(){
		Debug.Log("rip tower");
		Destroy(gameObject);
	}
}

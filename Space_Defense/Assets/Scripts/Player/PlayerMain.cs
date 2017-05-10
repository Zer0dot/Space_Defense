using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {

	public static float money = 0.0f;
	public static int health = 100;
	//private static int maxHealth = 0;

	void Start(){
	//	maxHealth = health;
	}
	//method to edit money
	public static void EditMoney(string setting, float quantity = 0.0f){
		if (setting == "add"){
			money += quantity;
		}else if (setting == "substract"){
			money -= quantity;
		}

		UIUpdate.UIUpdateMoney(money);
	}

	//method to edit health
	public static void EditHealth(string setting, int quantity = 0){
		if (setting == "heal"){
			health += quantity;
		}else if (setting == "damage"){
			health -= quantity;
		}

		if (health <= 0){
			Death();
		}
	}

	private static void Death(){
		Debug.Log("hah");
	}
}

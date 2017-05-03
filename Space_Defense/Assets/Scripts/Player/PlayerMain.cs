using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {

	public static float money = 0.0f;

	//method to edit money
	public static void EditMoney(string setting, float quantity = 0.0f){
		if (setting == "add"){
			money += quantity;
		}else if (setting == "substract"){
			money -= quantity;
		}

		UIUpdate.UIUpdateMoney(money);
	}



}

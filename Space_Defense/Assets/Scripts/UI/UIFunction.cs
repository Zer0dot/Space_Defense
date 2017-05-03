using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunction : MonoBehaviour {

	[SerializeField]private int turretQuantity = 1;
	[SerializeField]private int gunQuantity = 5;
	[SerializeField]private float turretCost = 15f;
	[SerializeField]private float gunCost = 10f;


	void Start(){
		Debug.Log(Shoot.damage);
	}

	public void AddTurretDamage(){
		if (PlayerMain.money >= turretCost){
			TowerTarget.EditTurretDamage("add", turretQuantity);
			PlayerMain.EditMoney("substract", turretCost);
			UIUpdate.UIUpdateTurretDamage(TowerTarget.turretDamage);
		}
	}

	public void AddGunDamage(){
		if (PlayerMain.money > gunCost){
			Shoot.EditGunDamage("add", gunQuantity);
			PlayerMain.EditMoney("substract", gunCost);
			UIUpdate.UIUpdateGunDamage(Shoot.damage);
		}
	}
}

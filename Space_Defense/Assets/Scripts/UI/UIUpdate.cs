using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour {
	private static Text moneyField;
	private static Text turretDamageField;
	private static Text gunDamageField;
	[SerializeField]private GameObject _menuCanvas;
	//THE FUNCTIONS HERE DO NOT AFFECT THE ACTUAL VALUES, THEY DISPLAY THEM

	void Start(){
		moneyField = GameObject.FindWithTag("MoneyField").GetComponent<Text>();
		turretDamageField = GameObject.FindWithTag("TurretDamageField").GetComponent<Text>();
		gunDamageField = GameObject.FindWithTag("GunDamageField").GetComponent<Text>();


		UIUpdateMoney();
		UIUpdateTurretDamage();
		UIUpdateGunDamage();
		_menuCanvas.SetActive(false);
	}

	public static void UIUpdateMoney (float _money = 0.0f) {
		if (moneyField != null){
			moneyField.text = _money.ToString("F2") + "$";
		}

	}
		
	public static void UIUpdateTurretDamage(int _turretDamage = 1){
		if (turretDamageField != null){
			turretDamageField.text = "Turret damage: " + _turretDamage;
		}
	}

	public static void UIUpdateGunDamage(int _gunDamage = 1){
		if (gunDamageField != null){
			gunDamageField.text = "Gun damage: " + _gunDamage;
		}
	}
}

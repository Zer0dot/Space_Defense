using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusMain : MonoBehaviour {
	[SerializeField]private static int currentHP;

	public static void Damage(int damageValue){
		currentHP -= damageValue;
	}
}

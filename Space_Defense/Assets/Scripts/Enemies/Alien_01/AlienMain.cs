using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMain : MonoBehaviour {

	public static List<Transform> enemies = new List<Transform>();

	[SerializeField]private static int maxHealth;
	private int currentHealth;


	void Start(){
		enemies.Add(GetComponent<Transform>());
		currentHealth = maxHealth;
		Debug.Log(enemies[0].gameObject);
	}

	void Damage(int _damage){
		currentHealth -= _damage;
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMain : MonoBehaviour {

	public static List<Transform> enemies = new List<Transform>();//Used in tower targeting to select closest target among enemies

	[SerializeField]private int maxHealth = 100;


	private int currentHealth;


	void Start(){
		enemies.Add(GetComponent<Transform>());//Appends the transform to the enemies array
		currentHealth = maxHealth;//Initializes the health value
		Debug.Log(enemies[0].gameObject);
	}

	void Damage(int _damage){
		currentHealth -= _damage;
		Debug.Log(currentHealth);
		if (currentHealth <= 0){
			Death();
		}
	}

	void Death(){
		enemies.Remove(transform);
		Destroy(gameObject);
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour {

	[SerializeField]private GameObject enemyToSpawn;
	[SerializeField]private float delay = 5f;

	void Start () {
		if (enemyToSpawn != null){
			StartCoroutine(spawnEnemy());
		}

	}


	//SpawnEnemy instantiates the given enemy prefab with the given delay
	private IEnumerator spawnEnemy(){
		while (true){
			yield return new WaitForSeconds(delay);
			Instantiate(enemyToSpawn, transform.position, Quaternion.identity);	
		}

	}

}

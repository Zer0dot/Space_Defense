using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AlienBasic : MonoBehaviour {

	[SerializeField]private float aggroDistance;//Distance from player at which alien will aggro
	[SerializeField]private float speed;

	private Transform target;//Either nexus or player
	private Transform nexus;//nexus
	private Transform player;//player
	//private float nexusDistance;//Distance from enemy to nexus found to be obsolete
	private float playerDistance;//Distance from enemy to player

	void Start(){
		nexus = GameObject.FindWithTag("Core").transform;//Gets Nexus transform
		player = GameObject.FindWithTag("Player").transform;//Gets Player transform
		target = nexus;
		StartCoroutine(IntervalTargeting());
	}

	void Update(){
		Debug.Log("l");
		//nexusDistance = GetDistance(nexus);//Gets distance from nexus found to be obsolete
		playerDistance = GetDistance(player);//Gets distance from player
		Movement(target);


		Quaternion wantedRotation;
		wantedRotation = Quaternion.LookRotation(target.position - transform.position);//Gets the direction vector in which to look	
		transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.fixedDeltaTime*1.5f);

	}

	//Coroutine selects target with a cooldown to prevent jittery targeting
	private IEnumerator IntervalTargeting(){
		while (true){
			target = GetTarget(playerDistance, aggroDistance);
			yield return new WaitForSeconds(2f);
		}

	}

	//Gets distance between enemy and other object
	float GetDistance(Transform other){
		float distance = Vector3.Distance(other.position, transform.position);//Gets distance from a given object
		return distance;
	}

	//GetTarget had float _nexusDistance as a parameter, found to be obsolete so removed
	//Chooses whether to target nexus or player appropriately
	Transform GetTarget(float _playerDistance, float _aggroDistance){
		if(_playerDistance <= _aggroDistance){
			return player;
		}
		else{
			return nexus;
		}
	}

	void Movement(Transform _target){
		

		GetComponent<Rigidbody>().velocity = speed*transform.forward;
	}
}

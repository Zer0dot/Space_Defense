using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerTarget: MonoBehaviour {


	//Will make dynamic target acquisition, note that the tower MUST fire before changing targets at least once, but it might work otherwise.
	private Transform target;

	void Start(){
		//target = GameObject.FindWithTag("Player").transform;
	}

	void Update () {
		target = GetTarget(AlienMain.enemies);
		if (target != null){
			transform.LookAt(target);
		}
		//Debug.Log(AlienMain.enemies[0]);

	}

	//GetTarget gets the nearest enemy from the turret's position, does not use Vector3.distance as that uses a square root calculation, which is less efficient
	Transform GetTarget(List<Transform> _enemies){
		
		Transform _target = null;//The enemy to return
		float smallestDistanceSquared = Mathf.Infinity;//The smallest distance to the enemy
		Vector3 currentPosition = transform.position;//The current position of the turret

		foreach(Transform potentialTarget in _enemies){
			
			Vector3 directionToTarget = potentialTarget.position - currentPosition; //The direction vector to the potential target
			float distanceToTargetSqr = directionToTarget.sqrMagnitude;//The squared distance to target

			if (distanceToTargetSqr < smallestDistanceSquared){
				smallestDistanceSquared = distanceToTargetSqr;
				_target = potentialTarget;

			}
		}
		//Debug.Log(_target);
		return _target;

	}
}

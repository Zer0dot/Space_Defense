using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AlienPathing : MonoBehaviour {

	[SerializeField]private float aggroDistance;//Distance from player at which alien will aggro
	[SerializeField]private float speed;
	[SerializeField]private float keepDistance;//Distance to keep from target (MUST be lower than aggroDistance)

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
		MoveRotation(target);//When in FixedUpdate, the rotation is too slow
	}

	void FixedUpdate(){
		//nexusDistance = GetDistance(nexus);//Gets distance from nexus found to be obsolete
		playerDistance = GetDistance(player);//Gets distance from player

		//Checks if game is paused before executing movement, this is important because otherwise  when pausing the creature keeps a bit of momentum(?weird?)
		if (Time.timeScale != 0f){
			Movement(target);
		}

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

	//MoveRotation rotates the alien towards the target
	void MoveRotation(Transform _target){
		Quaternion wantedRotation;
		wantedRotation = Quaternion.LookRotation(_target.position - transform.position);//Gets the direction vector in which to look	
		transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.fixedDeltaTime*1.5f); //Interpolates to the wanted rotation, fixedDeltaTime is necessary, Time.Time makes it only occur once at the beginning as "t" parameter capped at 1
	}

	//Movement manages the movement towards the target
	void Movement(Transform _target){
		float distanceFromTarget = GetDistance(_target);

		Rigidbody body = GetComponent<Rigidbody>();//The attached Rigidbody component

		//Must have the keepDistance multiple to create an artificial zone where the creature can reside without moving, prevents jittering
		if (distanceFromTarget > (keepDistance + 0.3f*keepDistance)){
			//if (body.velocity == Vector3.zero){
				body.AddForce(speed*transform.forward, ForceMode.Acceleration); // = speed*transform.forward;
			//}

		}
		else if(distanceFromTarget < (keepDistance - 0.3f*keepDistance)){
		//	if (body.velocity == Vector3.zero){
				body.AddForce(-speed*transform.forward, ForceMode.Acceleration); //= -1.5f*speed*transform.forward;
			//}

		}
		else{
			body.velocity = body.velocity*0.99f; //Smoothes the alien's stopping
		}
	}
}

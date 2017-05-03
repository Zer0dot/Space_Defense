using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerTarget: MonoBehaviour {


	//Will make dynamic target acquisition, note that the tower MUST fire before changing targets at least once, but it might work otherwise.
	private Transform target;

	[SerializeField]private Material turretLineMaterial;

	public static int turretDamage = 1;

	[SerializeField]private float turretCooldown = 0.5f;
	void Start(){
		//target = GameObject.FindWithTag("Player").transform;
		StartCoroutine(FireSequence(turretCooldown));
	}

	void Update () {
		target = GetTarget(AlienMain.enemies);
		if (target != null){
			transform.LookAt(target);

		}
		//Debug.Log(AlienMain.enemies[0]);
	}

	public static void EditTurretDamage(string operation, int number){
		if (operation == "add"){
			turretDamage += number;
		}else if (operation == "substract"){
			turretDamage -= number;
		}
	}

	private IEnumerator FireSequence(float _cooldown){
		while (true){
			yield return new WaitForSeconds(_cooldown);
			Transform _target = GetTarget(AlienMain.enemies);
			if (_target != null){
				Fire(_target);
			}

		}
	


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

	//Fire sends the shot data to the hit enemy and calls the DrawLine function to graphically represent the shot
	void Fire(Transform _target){

		Vector3 selfPosition = transform.position;
		Vector3 enemyPosition = _target.position;

		float distanceSquared = (enemyPosition - selfPosition).sqrMagnitude;
		float distanceToFireSquared = 3600;
		
		if (distanceSquared <= distanceToFireSquared){
			DrawLine(selfPosition, enemyPosition, turretLineMaterial);
			_target.SendMessage("Damage", turretDamage);
		}
	}

	//Same DrawLine as in player's shoot script, for some reason won't work in another script
	void DrawLine(Vector3 start, Vector3 end, Material _lineMaterial, float duration = 0.2f){
		GameObject line = new GameObject();
		line.transform.SetParent(transform);
		line.transform.position = Vector3.zero;


		line.AddComponent<LineRenderer>();
		LineRenderer lr = line.GetComponent<LineRenderer>();
		lr.material = _lineMaterial;

		lr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

		lr.useWorldSpace = false;

		//lr.startColor = color; Removed, using material settings instead
		//lr.endColor = color; Removed, using material settings instead

		lr.startWidth = 0.05f;
		lr.endWidth = 0.05f;

		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
		GameObject.Destroy(line, duration);
	}
}

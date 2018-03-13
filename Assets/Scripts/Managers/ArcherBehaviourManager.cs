using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBehaviourManager : MonoBehaviour {
	private MonoBehaviour behaviour;
	private float range = 3f;
	private List<Prey> nearPrey = new List<Prey>();

	private void Awake () {
		behaviour = gameObject.AddComponent<ScoutBehaviour>();
	}
	
	private void Update () {
		if (behaviour is ScoutBehaviour) {
			Debug.Log("Scouting");
		} else if (behaviour is ScoutBehaviour && nearPrey.Count > 0) {
			Destroy(behaviour);
			behaviour = gameObject.AddComponent<SneakBehaviour>();
		}
		else {
			Debug.Log("Missing or incorrect behaviour");
		}
		
		//float dist = Vector3.Distance(transform.position, target.transform.position);
		//if (dist <= range) {
		//	nearPrey.Add(target);
		//}
	}

	private void OnTriggerEnter(Collider col) {
		try {
			nearPrey.Add(col.gameObject.GetComponent<Prey>());
		}
		catch (Exception e) {
			Debug.Log("Item does not have Prey component");
		}
	}

	private void OnTriggerExit(Collider col) {
		nearPrey.Remove(col.gameObject.GetComponent<Prey>());
	}

	private void OnDrawGizmos() {
		//Draw the range in which it can see
	}
}

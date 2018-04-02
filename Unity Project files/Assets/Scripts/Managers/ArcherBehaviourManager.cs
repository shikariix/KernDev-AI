using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBehaviourManager : MonoBehaviour {
	private MonoBehaviour behaviour;
	private float range = 30f;
	private List<Prey> nearPrey = new List<Prey>();

	private void Awake () {
		behaviour = gameObject.AddComponent<ScoutBehaviour>();
		nearPrey.Clear();
	}
	
	private void Update () {
		if (behaviour is ScoutBehaviour && nearPrey.Count > 0) {
			Destroy(behaviour);
			behaviour = gameObject.AddComponent<SneakBehaviour>();
		}
		else if (behaviour is ScoutBehaviour) {
			Debug.Log("Scouting");
		}

		if (behaviour is SneakBehaviour && nearPrey.Count == 0) {
			Destroy(behaviour);
			behaviour = gameObject.AddComponent<ScoutBehaviour>();
		} else if (behaviour is SneakBehaviour) {
			Debug.Log("Sneaking");
		}
		
	}

	private void OnTriggerStay(Collider col) {
		if (col.gameObject.CompareTag("Prey")) {
			float dist = Vector3.Distance(transform.position, col.transform.position);
			if (dist <= range && !nearPrey.Contains(col.gameObject.GetComponent<Prey>())) {
				nearPrey.Add(col.gameObject.GetComponent<Prey>());
			}
		}
	}


	private void OnTriggerExit(Collider col) {
		nearPrey.Remove(col.gameObject.GetComponent<Prey>());
	}

}

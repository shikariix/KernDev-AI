using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyBehaviourManager : MonoBehaviour {

	private MonoBehaviour behaviour;
	private Prey prey;
	
	void Awake () {
		behaviour = gameObject.AddComponent<CalmBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		if (behaviour is CalmBehaviour) {
			Debug.Log("Grazing");
		} else if (behaviour is CalmBehaviour && prey.isHit) {
			Destroy(behaviour);
			behaviour = gameObject.AddComponent<SneakBehaviour>();
		}
		else {
			Debug.Log("Missing or incorrect behaviour");
		}
	}
}

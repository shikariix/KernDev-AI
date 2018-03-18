using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalmBehaviour : MonoBehaviour {

	private PreyHerdManager herdManager;
	private Prey thisPrey;
	
	private Vector3 v1, v2, v3;
	private float separationRadius = 5f;
	private float herdRadius = 15f;

	private float cohesionWeight = 0.5f;
	private float separationWeight = 0.1f;
	private float alignmentWeight = 0.5f;

	void Start() {
		thisPrey = GetComponent<Prey>();
		herdManager = GetComponentInParent<PreyHerdManager>();
	}
	
	void FixedUpdate () {
		v1 = Cohere(thisPrey) * cohesionWeight;
		v2 = Separate(thisPrey) * separationWeight;
		v3 = Align(thisPrey) * alignmentWeight;
		
		thisPrey.velocity = thisPrey.velocity + v1 + v2 + v3;
		
		//thisPrey.transform.position = thisPrey.transform.position + thisPrey.velocity;
		
		//keep within bounds
		if (transform.position.x >= 50 || transform.position.x <= -50) {
			thisPrey.velocity.x = -thisPrey.velocity.x;
		}
		if (transform.position.z >= 50 || transform.position.z <= -50) {
			thisPrey.velocity.z = -thisPrey.velocity.z;
		}
	}

	//steer towards flock
	private Vector3 Cohere(Prey b) {
		Vector3 centerOfMass = Vector3.zero;
		foreach (Prey p in herdManager.herd) {
			if (p != b) {
				centerOfMass += p.transform.position;
			}
		}

		centerOfMass = centerOfMass / (herdManager.herdSize - 1);
		return (centerOfMass - b.transform.position) / 100;
	}
	
	//avoid bumping into eachother
	private Vector3 Separate(Prey b) {
		Vector3 c = Vector3.zero;
		
		foreach (Prey p in herdManager.herd) {
			if (p != b) {
				float dist = Vector3.Distance(b.transform.position, p.transform.position);
				if (dist < separationRadius) {
					c = c - (p.transform.position - b.transform.position);
				}
			}
		}

		//c = c / (herdManager.herdSize - 1);
		return c;
	}
	
	//move towards general heading
	private Vector3 Align(Prey b) {
		Vector3 velocity = Vector3.zero;
		
		foreach (Prey p in herdManager.herd) {
			if (p != b) {
				velocity += p.velocity;
			}
		}
		velocity = velocity / (herdManager.herdSize - 1);
		
		return (velocity - b.velocity) / 8;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutBehaviour : MonoBehaviour {

	private Rigidbody rb;
	public Vector3 dir;
	
	void Awake() {
		rb = GetComponent<Rigidbody>();
		dir = new Vector3(1, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = dir * 2;

		int random = Random.Range(0, 200);
		
		if (random == 1) {
			ChangeDirection();
		}
		
		//keep within bounds
		if (transform.position.x >= 50) {
			dir.x = -1;
		} 
		else if (transform.position.x <= -50) {
			dir.x = 1;
		}
		
		if (transform.position.z >= 50) {
			dir.z = -1;
		} 
		else if (transform.position.z <= -50) {
			dir.z = 1;
		}
	}

	void ChangeDirection() {
		int newX = Random.Range(-1, 2);
		int newZ = Random.Range(-1, 2);
		
		dir = new Vector3(newX, 0, newZ);
	}
}

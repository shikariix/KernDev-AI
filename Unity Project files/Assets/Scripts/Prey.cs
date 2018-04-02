using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : MonoBehaviour {

	public bool isHit;
	
	//Do I save HP as variable in Prey or as a separate stat file?

	[SerializeField]
	public Vector3 velocity;
	public Rigidbody rb;
	
	private Vector3 temp;

	void Start() {
		velocity = new Vector3(Random.Range(-1f, 2), 0, Random.Range(-1f, 2));
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		rb.velocity = velocity;
	}
}

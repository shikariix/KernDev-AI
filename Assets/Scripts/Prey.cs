using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : MonoBehaviour {

	public bool isHit;
	
	//Do I save HP as variable in Prey or as a separate stat file?

	[SerializeField]
	public Vector3 velocity;

	private Vector3 temp;

	void Start() {
		velocity = new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(-0.1f, 0.1f));
		
	}

	void Update() {
		//rotate towards heading
		temp = transform.rotation.eulerAngles;
		Vector3 heading = Vector3.zero;
		heading.y = temp.x - temp.z;
		transform.rotation = Quaternion.Euler(heading);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakBehaviour : MonoBehaviour {

	private List<Transform> nearTrees = new List<Transform>();
	private Transform closestTree;
	private float distToClosest;
	
	// Use this for initialization
	void Awake () {
		Destroy(closestTree);
	}
	
	// Update is called once per frame
	void Update () {
		if (distToClosest != Mathf.Infinity) {
			float step = 1f * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, closestTree.position, step);
		}
		else {
			FindHidingSpot();
		}
		Debug.Log(distToClosest);
	}
	
	private void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag("Tree")) {
			nearTrees.Add((col.gameObject.transform));
		}
	}

	private void OnTriggerExit(Collider col) {
		nearTrees.Remove(col.gameObject.transform);
	}

	private void FindHidingSpot() {
		//Find the closest hiding spot
		distToClosest = Mathf.Infinity;
		foreach (Transform tree in nearTrees) {
			float dist = Vector3.Distance(transform.position, tree.position);
			Debug.Log("Distance = " + dist);
			if(dist < distToClosest) {
				Debug.Log("New closest = " + distToClosest);
				distToClosest = dist;
				closestTree = tree;
			}
		}
	}
}

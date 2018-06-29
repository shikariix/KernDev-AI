using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTree : MonoBehaviour {

    private Vector3 pos;
    private Vector3 size;

	// Use this for initialization
	void Start () {
        float randomWidth = Random.Range(0.2f, 0.6f);
        float randomHeight = Random.Range(0.8f, 1.3f);
        size = new Vector3(randomWidth, randomHeight, randomWidth);

        transform.localScale = size;
        transform.position += pos;
	}
	
}

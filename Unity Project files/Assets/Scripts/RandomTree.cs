using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTree : MonoBehaviour {

    private Vector3 pos;
    private Vector3 size;

	// Use this for initialization
	void Start () {
        float randomWidth = Random.Range(0.2f, 1f);
        float randomHeight = Random.Range(1f, 3f);
        float randomX = Random.Range(-0.2f, 0.2f);
        float randomZ = Random.Range(-0.2f, 0.2f);
        pos = new Vector3(randomX, 0, randomZ);
        size = new Vector3(randomWidth, randomHeight, randomWidth);

        transform.localScale = size;
        transform.position += pos;
	}
	
}

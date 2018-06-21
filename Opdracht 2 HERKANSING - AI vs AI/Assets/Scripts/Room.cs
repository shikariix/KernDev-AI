using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public int maxWidth;
    public int maxDepth;

    public Vector3 position;

	// Use this for initialization
	void Start () {
        SetSize();
        position = transform.position;
	}
	
	void SetSize() {
        if (maxWidth > 0 && maxDepth > 0) {
            transform.localScale = new Vector3(Random.Range(1, maxWidth), transform.localScale.y, Random.Range(1, maxDepth));
        }
        else {
            transform.localScale = new Vector3(Random.Range(1, 5), transform.localScale.y, Random.Range(1, 5));
        }
    }
}

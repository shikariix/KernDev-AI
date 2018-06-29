using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    //size & placement of room
    public int maxWidth;
    public int maxDepth;
    public Vector3 position;

    public List<GameObject> currentVisitors;

    // Use this for initialization
    void Start() {
        SetSize();
        position = transform.position;
        currentVisitors = new List<GameObject>();
    }

    //keep track of every object that is currently in the room
    void OnCollisionEnter(Collision col) {
        if (!currentVisitors.Contains(col.gameObject)) { 
            if (col.gameObject.tag == "Archer" || col.gameObject.tag == "Animal") {
                currentVisitors.Add(col.gameObject);
            }
        }
    }

    void OnCollisionExit(Collision col) {
        if (currentVisitors.Contains(col.gameObject)) {
            currentVisitors.Remove(col.gameObject);
        }
    }

	
	void SetSize() {
        if (maxWidth > 0 && maxDepth > 0) {
            transform.localScale = new Vector3(Random.Range(1, maxWidth), transform.localScale.y, Random.Range(1, maxDepth));
        }
        else {
            //transform.localScale = new Vector3(Random.Range(1, 5), transform.localScale.y, Random.Range(1, 5));
        }
    }
}

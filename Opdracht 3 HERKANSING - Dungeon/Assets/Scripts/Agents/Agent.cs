using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {
    
    public MovingTasks movingTasks;

    void Start () {
        movingTasks = GetComponent<MovingTasks>();
    }
	
    //move closer to target agent
    public void MoveToNextNode(Vector3 targetPos) {
        movingTasks.FindPath(transform.position, targetPos);
        if (movingTasks.path.Count > 1) transform.position = movingTasks.path[1].worldPos;
    }
}

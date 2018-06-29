using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class Agent : MonoBehaviour {
    
    public MovingTasks movingTasks;
    public Room currentRoom;
    public GameObject player;

    void Start () {
        movingTasks = GetComponent<MovingTasks>();
    }

    [Task]
    public void CheckForPlayer() {
        player = null;
        if (currentRoom != null) {
            for (int i = 0; i < currentRoom.currentVisitors.Count; i++) {
                if (currentRoom.currentVisitors[i].tag == "Player") {
                    player = currentRoom.currentVisitors[i];
                    Task.current.Succeed();
                    break;
                }
            }
        }
        if (player == null) Task.current.Fail();
    }

    //move closer to target agent
    public void MoveToNextNode(Vector3 targetPos) {
        movingTasks.FindPath(transform.position, targetPos);
        if (movingTasks.path.Count > 1) transform.position = movingTasks.path[1].worldPos;
    }

}

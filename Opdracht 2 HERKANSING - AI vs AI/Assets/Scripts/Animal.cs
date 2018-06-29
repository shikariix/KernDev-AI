using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class Animal : Agent {

    public bool isTamed = false;
    Archer leader;
    Room currentRoom;

    [Task]
    void IsTamed() {
        if (isTamed) Task.current.Succeed();
        else Task.current.Fail();
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Archer") {
            leader = col.gameObject.GetComponent<Archer>();
        }
    }

    void OnCollisionEnter(Collision col) {
        //detect current room
        if (col.gameObject.tag == "Room") {
            currentRoom = col.gameObject.GetComponent<Room>();
        }
    }

    [Task]
    void CheckForArcher() {
        for (int i = 0; i < currentRoom.currentVisitors.Count; i++) {
            if (currentRoom.currentVisitors[i].GetComponent<Archer>() != null) {
                Task.current.Succeed();
                break;
            }
            Task.current.Fail();
        }
        
    }

    [Task]
    void IsArcherInRange() {
        if (leader != null) Task.current.Succeed();
        else Task.current.Fail();
    }

    [Task]
    void TameThisAnimal() {
        isTamed = true;
        Task.current.Succeed();
    }

    [Task]
    void FollowLeader() {
        //Debug.Log(gameObject.name + " following leader.");
        transform.LookAt(leader.transform);
        //movingTasks.FindPath(transform.position, leader.transform.position);

        //MoveToNextNode(leader.transform.position);
        transform.position = Vector3.Lerp(transform.position, leader.transform.position, 0.05f);
        Task.current.Succeed();
    }
}

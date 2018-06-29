using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class Animal : Agent {

    public bool isTamed = false;
    Archer leader;

    [Task]
    void IsTamed() {
        if (isTamed) Task.current.Succeed();
        else Task.current.Fail();
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Archer") {
            leader = col.gameObject.GetComponent<Archer>();
        }
        if (col.gameObject.tag == "Player") {
            player = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Player") {
            player = null;
        }
    }

    [Task]
    void CheckForArcher() {
        if (currentRoom == null) {
            Task.current.Fail();
            return;
        }
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
        if (leader != null && !isTamed) Task.current.Succeed();
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
        float distance = Vector3.Distance(transform.position, leader.transform.position);
        
        if (distance > 3) MoveToNextNode(leader.transform.position); //not smooth at all but it works I guess
        //transform.position = Vector3.Lerp(transform.position, leader.transform.position, 0.05f);
        if (player != null) Task.current.Fail();
        else Task.current.Succeed();
    }

    [Task]
    void FollowPlayer() {
        transform.LookAt(player.transform);
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > 2) MoveToNextNode(player.transform.position); //not smooth at all but it works I guess
        Task.current.Succeed();
    }
}

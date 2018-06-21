using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class Animal : MonoBehaviour {

    bool isTamed = false;
    Archer leader;

    [Task]
    void IsTamed() {
        if (isTamed) Task.current.Succeed();
        else Task.current.Fail();
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Archer") {
            leader = col.gameObject.GetComponent<Archer>(); 
            isTamed = true;
        }
    }


    [Task]
    void FollowLeader() {
        Debug.Log("Following leader.");
        float distance = Vector3.Distance(transform.position, leader.transform.position);
        if (distance > 2) transform.position = Vector3.Lerp(transform.position, leader.transform.position, 0.1f);
        Task.current.Succeed();
    }
}

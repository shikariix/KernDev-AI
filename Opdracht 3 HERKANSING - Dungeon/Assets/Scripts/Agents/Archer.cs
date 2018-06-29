using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class Archer : Agent {

    private Animal inRange;
    private Animal target;
    private Room currentRoom;
    public List<Animal> tamedAnimals;

    void Awake() {
        tamedAnimals = new List<Animal>();
    }

    void OnCollisionEnter(Collision col) {
        //detect current room
        if (col.gameObject.tag == "Room") {
            currentRoom = col.gameObject.GetComponent<Room>();
        } else {
            currentRoom = null;
        }
    }

    [Task]
    void CheckForAnimal() {
        if (currentRoom != null ) { 
            for (int i = 0; i < currentRoom.currentVisitors.Count; i++) {
                if (currentRoom.currentVisitors[i].GetComponent<Animal>() != null && !currentRoom.currentVisitors[i].GetComponent<Animal>().isTamed && !tamedAnimals.Contains(currentRoom.currentVisitors[i].GetComponent<Animal>())) {
                    target = currentRoom.currentVisitors[i].GetComponent<Animal>();
                    break;
                }
            }
        }
        if (target == null) Task.current.Fail();
        else Task.current.Succeed();
    }

    [Task]
    void AnimalInRange() {
        if (inRange != null) Task.current.Succeed();
        else Task.current.Fail();
    }

    [Task]
    void ChaseAnimal() {
        //Vector3 distance = target.transform.position - transform.position;
        //transform.position += distance.normalized / 10;
        MoveToNextNode(target.transform.position);

        if (Vector3.Distance(target.transform.position, transform.position) < 3) inRange = target;
        Task.current.Succeed();
    }

    [Task]
    void TameAnimal() {
        if (!tamedAnimals.Contains(inRange)) {
            tamedAnimals.Add(inRange);
            target = null;
            inRange = null;
            Task.current.Succeed();
        }
        else Task.current.Fail();
    }
}

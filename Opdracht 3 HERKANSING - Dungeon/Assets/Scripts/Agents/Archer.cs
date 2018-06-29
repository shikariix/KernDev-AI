using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class Archer : Agent {

    private Animal inRange;
    private Animal target;
    public List<Animal> tamedAnimals;
    public GameObject dartPrefab;

    void Awake() {
        tamedAnimals = new List<Animal>();
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.GetComponent<Animal>() != null) {
            inRange = col.gameObject.GetComponent<Animal>();
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
    void ShootAtPlayer() {
        transform.LookAt(player.transform);
        GameObject dart = Instantiate(dartPrefab, transform.position + Vector3.up, transform.rotation);
        dart.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        Task.current.Succeed();
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

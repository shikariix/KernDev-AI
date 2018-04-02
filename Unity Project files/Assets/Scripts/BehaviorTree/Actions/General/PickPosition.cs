using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPosition : Node {
    private List<Room> roomsList = new List<Room>();
    private Archer agent;

    public override void Init(Hashtable data) {
        GameObject[] roomsArray = GameObject.FindGameObjectsWithTag("Room");
        foreach (GameObject obj in roomsArray) {
            roomsList.Add(obj.GetComponent<Room>());
        }
        GameObject temp = GameObject.FindWithTag("Archer");
        agent = temp.GetComponent<Archer>();
        Debug.Log("PickPosition Entered");
    }

    public override Result Process() {
        Result result = Result.RUNNING;

        Vector3 newPosition;

        if (roomsList.Count > 0) {
            int randomIndex = Random.Range(0, roomsList.Count);
            newPosition = roomsList[randomIndex].GetCenter();
        } else {
            newPosition = agent.transform.position + new Vector3(Random.Range(0, 20), 0, Random.Range(0, 20));
        }
        
        agent = GameObject.FindWithTag("Archer").GetComponent<Archer>();
        agent.SetTargetPosition(newPosition);
        Debug.Log("Exiting PickPosition");
        result = Result.SUCCESS;
        
        return result;
    }
    
}

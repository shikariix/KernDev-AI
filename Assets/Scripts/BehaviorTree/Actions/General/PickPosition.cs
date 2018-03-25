using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPosition : Node {
    private List<Room> roomsList = new List<Room>();
    private Archer agent;

    public override void Init() {
        GameObject[] roomsArray = GameObject.FindGameObjectsWithTag("Room");
        foreach (GameObject obj in roomsArray) {
            roomsList.Add(obj.GetComponent<Room>());
        }
        GameObject temp = GameObject.FindWithTag("Archer");
        agent = temp.GetComponent<Archer>();
    }

    public override Result Process(Dictionary<string, object> dataStore) {
        Result result = Result.RUNNING;
        Debug.Log("PickPosition Entered");
        Debug.Log(agent.gameObject.name);

        Vector3 newPosition;

        if (roomsList.Count > 0) {
            int randomIndex = Random.Range(0, roomsList.Count);
            newPosition = roomsList[randomIndex].GetCenter();
        } else {
            newPosition = new Vector3(Random.Range(0, 20), 0, Random.Range(0, 20));
        }

        if (newPosition != null) {
            agent = GameObject.FindWithTag("Archer").GetComponent<Archer>();
            agent.SetTargetPosition(newPosition);
            Debug.Log("Exiting PickPosition");
            result = Result.SUCCESS;
        }

        return result;
    }
    
}

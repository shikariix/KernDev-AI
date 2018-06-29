using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
	
	public GameObject tilePrefab;
	public int roomX;
	public int roomZ;
	public int roomWidth;
	public int roomHeight;

    public List<DungeonPath> paths = new List<DungeonPath>();
    public List<GameObject> currentVisitors;

    public Vector3 position;

    public void MakeRoom(int width, int height, int maxX, int maxZ) {
		roomWidth = width;
		roomHeight = height;
		roomX = maxX;
		roomZ = maxZ;
        position = new Vector3(roomX + (roomWidth / 2), 0, roomZ + (roomHeight / 2));
        BoxCollider col = gameObject.AddComponent<BoxCollider>();
        col.isTrigger = true;
        col.size = new Vector3(roomWidth, 2, roomHeight);
        col.center = position;

        currentVisitors = new List<GameObject>();


    }

    public Vector3 GetCenter() {
        return position;
    }

    //keep track of every object that is currently in the room
    void OnTriggerEnter(Collider col) {
        if (!currentVisitors.Contains(col.gameObject)) {
            if (col.gameObject.tag == "Archer" || col.gameObject.tag == "Animal" || col.gameObject.tag == "Player") {
                currentVisitors.Add(col.gameObject);
                if (col.gameObject.GetComponent<Agent>() != null) col.gameObject.GetComponent<Agent>().currentRoom = this;
            }
        }
    }

    void OnTriggerExit(Collider col) {
        if (currentVisitors.Contains(col.gameObject)) {
            currentVisitors.Remove(col.gameObject);
        }
    }
}

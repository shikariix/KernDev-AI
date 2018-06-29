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

        currentVisitors = new List<GameObject>();


    }

    public Vector3 GetCenter() {
        return new Vector3(roomX + (roomWidth / 2), 0, roomZ + (roomHeight / 2));
    }

    //keep track of every object that is currently in the room
    void OnCollisionEnter(Collision col) {
        if (!currentVisitors.Contains(col.gameObject)) {
            if (col.gameObject.tag == "Archer" || col.gameObject.tag == "Animal") {
                currentVisitors.Add(col.gameObject);
            }
        }
    }

    void OnCollisionExit(Collision col) {
        if (currentVisitors.Contains(col.gameObject)) {
            currentVisitors.Remove(col.gameObject);
        }
    }
}

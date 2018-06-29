using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour {

    static Room[] rooms;

    static void FindRooms() {
        rooms = FindObjectsOfType<Room>();
        Debug.Log("Active rooms: " + rooms.Length);
    }
	
    //get room if there is no current room
    public static Room GetNewRoom() {
        if (rooms == null) FindRooms();
        return rooms[Random.Range(0, rooms.Length)];
    }

    public static Room GetNewRoom(Room current) {
        //Pick a random room to move to
        //If this random room is the current one, pick again
        int newRoomIndex = Random.Range(0, rooms.Length);
        if (current != rooms[newRoomIndex]) {
            return rooms[newRoomIndex];
        } else {
            return GetNewRoom(current);
        }
    }

}

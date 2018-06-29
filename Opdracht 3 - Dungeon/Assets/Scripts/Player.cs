using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public Room currentRoom;

    void OnCollisionEnter(Collision col) {
        //detect current room
        if (col.gameObject.tag == "Room") {
            currentRoom = col.gameObject.GetComponent<Room>();
        }
        else {
            currentRoom = null;
        }
    }
}

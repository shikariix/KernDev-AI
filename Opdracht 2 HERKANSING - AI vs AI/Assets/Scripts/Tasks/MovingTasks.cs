using UnityEngine;
using Panda;

public class MovingTasks : MonoBehaviour {

    Room currentRoom;
    Room oldRoom;

    float step = 0;
    public float speed;

    [Task]
    void MoveToNewRoom() {
        if (step < 1) step += Time.deltaTime * speed;
        else step = 1;
        transform.position = Vector3.Lerp(oldRoom.position, currentRoom.position, step);
        Task.current.Succeed();
    }

    [Task]
    void SetNewDestination() {
        if (currentRoom != null) oldRoom = currentRoom;
        Debug.Log("Picking new destination.");
        step = 0;
        currentRoom = GameInfo.GetNewRoom(currentRoom);
        if (oldRoom == null) oldRoom = currentRoom;
        Task.current.Succeed();
    }

    [Task]
    void HasReachedDestination() {
        if (transform.position == currentRoom.position) Task.current.Succeed();
        else Task.current.Fail();
    }
    
}

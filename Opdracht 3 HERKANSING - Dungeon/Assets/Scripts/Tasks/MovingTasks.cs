using UnityEngine;
using Panda;
using System.Collections.Generic;

public class MovingTasks : MonoBehaviour {

    Room currentRoom;
    Vector3 oldPosition;

    private int step = 0;
    public float speed;
    private NodeGrid grid;
    public List<Node> path;
    bool pathSet = false;

    void Start() {
        currentRoom = GameInfo.GetNewRoom();
        transform.position = currentRoom.position;
        grid = FindObjectOfType<NodeGrid>();
        path = new List<Node>();
        FindPath(oldPosition, currentRoom.position);
    }

    [Task]
    void MoveToNewRoom() {
        //Vector3 distance =  currentRoom.position - oldPosition;
        //transform.position += distance.normalized / 10;
        //transform.position = Vector3.Lerp(oldPosition, currentRoom.position, step);
        if (!pathSet) {
            FindPath(oldPosition, currentRoom.position);
            pathSet = true;
        }
        
        if (++step < path.Count) transform.position = path[step].worldPos;
        

        if (step < path.Count-1) transform.LookAt(path[step+1].worldPos);
        Task.current.Succeed();
    }

    [Task]
    void SetNewRoomDestination() {
        oldPosition = transform.position;
        step = 0;
        currentRoom = GameInfo.GetNewRoom(currentRoom);
        Task.current.Succeed();
    }

    [Task]
    void HasReachedDestination() {
        if (step > path.Count) {
            step = 0;
            pathSet = false;
            Task.current.Succeed();
        }
        else Task.current.Fail();
    }

    //A* pathfinding executed in this function
    public void FindPath(Vector3 startPos, Vector3 targetPos) {
        path.Clear();
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);


        Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0) {
            Node currentNode = openSet.RemoveFirst();
            closedSet.Add(currentNode);

            if (currentNode == targetNode) {
                RetracePath(startNode, targetNode);
                return;
            }

            //check values of neighboring nodes
            foreach (Node neighbour in grid.GetNeighbours(currentNode)) {
                if (!neighbour.walkable || closedSet.Contains(neighbour)) {
                    continue;
                }

                //if value is lowest, make it the next node
                int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                    else {
                        //openSet.UpdateItem(neighbour);
                    }
                }
            }
        }
    }

    //send found path to grid for displaying
    void RetracePath(Node startNode, Node endNode) {
        Node currentNode = endNode;

        while (currentNode != startNode) {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        grid.path = path;

    }

    int GetDistance(Node nodeA, Node nodeB) {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY) return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
    
}

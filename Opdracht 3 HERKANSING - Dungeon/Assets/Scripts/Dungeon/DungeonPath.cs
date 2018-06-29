using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPath : MonoBehaviour {

    public int startX;
    public int startZ;
    public int endX;
    public int endZ;

    Vector3 startPos;
    Vector3 endPos;
    

    public List<Vector2> tilesPositions = new List<Vector2>();

    public void CreatePath(Room startRoom, Room endRoom) {
        //decide where to start and end
        startX = startRoom.roomX + (startRoom.roomWidth / 2);
        startZ = startRoom.roomZ + (startRoom.roomHeight / 2);

        endX = endRoom.roomX + (endRoom.roomWidth / 2);
        endZ = endRoom.roomZ + (endRoom.roomHeight / 2);

        //find path between the two points
        tilesPositions.Add(new Vector2(startX, startZ));
        Vector2 currentSquare = tilesPositions[0];
        if (startX < endX) {
            while (currentSquare.x < endX) {
                currentSquare.x += 1;
                tilesPositions.Add(currentSquare);
            }
        } else {
            while (currentSquare.x >= endX) {
                currentSquare.x -= 1;
                tilesPositions.Add(currentSquare);
            }
        }
        if (startZ < endZ) { 
            while (currentSquare.y < endZ) {
                currentSquare.y += 1;
                tilesPositions.Add(currentSquare);
            }
        } else {
            while (currentSquare.y >= endZ) {
                currentSquare.y -= 1;
                tilesPositions.Add(currentSquare);
            }
        }
    }
}

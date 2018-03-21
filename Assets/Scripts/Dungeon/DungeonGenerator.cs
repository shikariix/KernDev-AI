using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour {

	public GameObject tilePrefab;
	public int areaWidth, areaHeight;
	public int roomMinWidth, roomMaxWidth, roomMinHeight, roomMaxHeight;
	public int roomAmount;
    
    public enum Tile {
        none,
        path
    }
    
    private Tile[,] grid;
	private Room[] rooms;
    private Path[] paths;
	private List<GameObject> tiles = new List<GameObject>();
    
    
	void Start () {
		grid = new Tile[areaWidth, areaHeight];
		GenerateDungeon();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			GenerateDungeon();
		}
	}

	private void GenerateDungeon() {
		foreach (Transform child in transform) {
			Destroy(child.gameObject);
		}

		rooms = new Room[roomAmount];
        paths = new Path[roomAmount];
		
		//generate positions and sizes for each room; generation should be done in the room itself, will work on that
		for (int k = 0; k < roomAmount; k++) {
			int roomWidth = Random.Range(roomMinWidth, roomMaxWidth);
			int roomHeight = Random.Range(roomMinHeight, roomMaxHeight);
			int roomX = Random.Range(0, areaWidth - roomWidth);
			int roomZ = Random.Range(0, areaHeight - roomHeight);
			GameObject room = new GameObject {name = "Room " + (k + 1)};
			room.transform.parent = transform;
			rooms[k] = room.AddComponent<Room>();
			rooms[k].MakeRoom(roomWidth, roomHeight, roomX, roomZ);

            //create a path for every room
            if (k > 0) { 
                GameObject path = new GameObject {name = "Path " + (k)};
                path.transform.parent = rooms[k-1].transform;
                paths[k-1] = path.AddComponent<Path>();
                rooms[k-1].paths.Add(paths[k-1]);
                if (k-1 == roomAmount-1) {
                paths[k-1].CreatePath(rooms[k-1], rooms[0]);
                } else { 
                    paths[k-1].CreatePath(rooms[k-1], rooms[k]);
                }
            }
        }
        
		SetTiles();
	}

	private void SetTiles() {
        
        //make the rooms
        foreach (Room r in rooms) {
            for (int i = 0; i < r.roomHeight; i++) {
                for (int j = 0; j < r.roomWidth; j++) {
                    //make sure the tile isnt taken yet
                    if (grid[r.roomX + j, r.roomZ + i] != Tile.path) {
                        GameObject temp = Instantiate(tilePrefab, new Vector3(r.roomX + j, 0, r.roomZ + i), Quaternion.identity);
                        temp.transform.parent = r.transform;
                        grid[r.roomX + j, r.roomZ + i] = Tile.path;
                        tiles.Add(temp);
                    }
                }
            }
        }
        
        foreach (Path p in paths) {
            for (int i = 0; i < roomAmount; i++) {
                foreach (Vector2 tilePos in p.tilesPositions) {
                    //make sure the tile isnt taken yet
                    if (grid[(int)tilePos.x, (int)tilePos.y] != Tile.path) {
                        GameObject temp = Instantiate(tilePrefab, new Vector3(tilePos.x, 0, tilePos.y), Quaternion.identity);
                        temp.transform.parent = p.transform;

                        grid[(int)tilePos.x, (int)tilePos.y] = Tile.path;
                        tiles.Add(temp);
                    }
                }
            }
        }
	}
}

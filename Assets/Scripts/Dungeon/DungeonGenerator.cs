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
		grid = new Tile[areaWidth, areaHeight];
		for (int k = 0; k < roomAmount; k++) {
			int roomWidth = Random.Range(roomMinWidth, roomMaxWidth);
			int roomHeight = Random.Range(roomMinHeight, roomMaxHeight);
			int roomX = Random.Range(0, areaWidth - roomWidth);
			int roomY = Random.Range(0, areaHeight - roomHeight);
			MakeRoom(roomX, roomY, roomWidth, roomHeight);
		}
	}

	private void MakeRoom(int x, int y, int xx, int yy) {
		for (int i = y; i < y+yy; i++) {
			for (int j = x; j < x+xx; j++) {
				grid[i, j] = Tile.path;
				GameObject temp = Instantiate(tilePrefab, new Vector3(i, 0, j), Quaternion.identity);
				temp.transform.parent = transform;
				tiles.Add(temp);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
	
	public GameObject tilePrefab;
	public int roomX;
	public int roomZ;
	public int roomWidth;
	public int roomHeight;

    public List<Path> paths = new List<Path>();
    

	public void MakeRoom(int width, int height, int maxX, int maxZ) {
		roomWidth = width;
		roomHeight = height;
		roomX = maxX;
		roomZ = maxZ;
	}
}

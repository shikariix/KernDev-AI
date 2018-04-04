using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {

	public void SpawnPlayerAt(Vector3 pos) {
        transform.position = new Vector3(pos.x, 5, pos.z);
    }
}

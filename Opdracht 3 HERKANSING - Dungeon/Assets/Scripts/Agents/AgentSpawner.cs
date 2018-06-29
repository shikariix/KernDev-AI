using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour {

    public GameObject prefab;
    public int spawnAmount;

	void Start () {
        StartCoroutine(SpawnObject());
	}

    IEnumerator SpawnObject() {
        for (int i = 0; i < spawnAmount; i++) {
            yield return new WaitForSeconds(0.01f);
            GameObject temp = Instantiate(prefab, transform);
        }
    }
}

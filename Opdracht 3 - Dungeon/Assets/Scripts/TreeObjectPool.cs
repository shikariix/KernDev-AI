using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObjectPool : MonoBehaviour {

    public int MAX_TREES;
    public GameObject treePrefab;

    public RandomTree[] objects;
    public int currentTree = 0;

    public void CreatePool(int areaWidth, int areaHeight) {
        Debug.Log(areaWidth + ", " + areaHeight);
        MAX_TREES = areaWidth * areaHeight;
        objects = new RandomTree[MAX_TREES];
        for (int i = 0; i < MAX_TREES; ++i) {
            //this creates the objects all on the same position
            //position should be changed on load
            objects[i] = Instantiate(treePrefab).GetComponent<RandomTree>();
            objects[i].gameObject.SetActive(false);
        }
    }

    //returns tree on given position
    public GameObject GetObject(Vector3 pos) {
        //activate current tree
        RandomTree tree = objects[currentTree];
        tree.gameObject.transform.position = pos;
        tree.gameObject.SetActive(true);

        //cycle through our trees, make sure to loop around
        if (++currentTree == MAX_TREES) {
            currentTree = 0;
        }

        return tree.gameObject;
    }
    
}

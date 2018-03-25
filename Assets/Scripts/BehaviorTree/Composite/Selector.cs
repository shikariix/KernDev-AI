using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : CompositeNode {
    //Selector: Runs every node until one succeeds

    private int currentNode, previousTick;

    public override void Init() {
        currentNode = 0;
        previousTick = -1;
    }

    public override Result Process(Dictionary<string, System.Object> dataStore) {
        Result result = Result.RUNNING;

        foreach (Node node in nodes) {
            node.Init();
            //for (currentNode = 0; currentNode < nodes.Count; currentNode++) {
            //Node node = nodes[currentNode];
            currentNode = nodes.IndexOf(node);
            // If this isn't the same node we were processing last tick then we need to Init it
            //if (currentNode != previousTick) node.Init();

            result = node.Process(dataStore);

            if (result == Result.FAILURE) continue;
            else break;
        }

        return result;
        
    }
}

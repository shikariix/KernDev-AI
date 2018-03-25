using System;
using System.Collections.Generic;
using UnityEngine;

public class CompositeNode : Node {

    public List<Node> nodes;
    private Node current_node;

    //Make node list and fill it
    public CompositeNode(List<Node> initial_list = null) {
        nodes = initial_list;
        if (nodes == null || nodes.Count == 0) {
            nodes = new List<Node>();
        }
    }

    public void AddNode(Node node) {
        nodes.Add(node);
    }

    public override void Init() {
        // Don't force implementation
        if (nodes.Count != 0) {
            current_node = nodes[0];
            current_node.Init();
        }
    }

    public override Result Process(Dictionary<string, System.Object> dataStore) {
        Result result = current_node.Process(dataStore);
        if (result == Result.RUNNING) {
            return result;
        }

        current_node = GetNextNode();
        current_node.Init();
        return Process(dataStore);
    }

    private Node GetNextNode() {
        int idx = nodes.IndexOf(current_node);
        return (idx == nodes.Count - 1 ? nodes[0] : nodes[idx + 1]);
    }
}

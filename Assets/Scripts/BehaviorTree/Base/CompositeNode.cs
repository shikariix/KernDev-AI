using System;
using System.Collections;
using UnityEngine;

public abstract class CompositeNode : Node {

    public Node[] children;

    public override void Init(Hashtable data) {
        foreach (Node child in children) {
            child.Init(data);
        }
    }
}

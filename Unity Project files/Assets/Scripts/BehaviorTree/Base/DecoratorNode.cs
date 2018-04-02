using System;
using System.Collections;
using UnityEngine;

public abstract class DecoratorNode : Node {

    public Node child;

    public override void Init(Hashtable data) {
        child.Init(data);
    }

}

using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecoratorNode : Node {

    public Node node { get; protected set; }

    public DecoratorNode(Node node) {
        this.node = node;
    }

    public override void Init() {
        node.Init();
    }

}

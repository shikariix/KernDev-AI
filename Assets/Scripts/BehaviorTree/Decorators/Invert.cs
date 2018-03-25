using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invert : DecoratorNode {

    public Invert(Node node) : base(node) {
        this.node = node;
    }

    public override Result Process(Dictionary<string, object> dataStore) {
        Result result = node.Process(dataStore);

        switch(result) {
        case Result.SUCCESS:
                return Result.FAILURE;
        case Result.FAILURE:
                return Result.SUCCESS;
        default:
                return Result.RUNNING;
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToLocation : Node {

    private Archer agent;
    Vector3 distance;

    public override void Init() {
        agent = GameObject.FindGameObjectWithTag("Archer").GetComponent<Archer>();

        distance = agent.transform.position - agent.targetPosition;
    }

    public override Result Process(Dictionary<string, object> dataStore) {
        Result result = Result.RUNNING;
        Debug.Log("WalkToPosition Entered");
        //quick hack: move to new position in 100 steps
        agent.transform.position += distance / 100;

        if (agent.transform.position == agent.targetPosition) {
            Debug.Log("Exiting WalkToPosition");
            result = Result.SUCCESS;
        }

        return result;
    }
}

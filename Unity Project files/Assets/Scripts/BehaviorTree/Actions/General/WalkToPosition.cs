using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToLocation : Node {

    private Archer agent;
    Vector3 distance, startPosition;

    public override void Init(Hashtable data) {
        agent = GameObject.FindGameObjectWithTag("Archer").GetComponent<Archer>();

        startPosition = agent.transform.position;
        distance = agent.targetPosition - agent.transform.position;
        Debug.Log("WalkToPosition Entered");
    }

    public override Result Process() {
        Result result = Result.RUNNING;
        
        agent.transform.position = Vector3.Lerp(startPosition, agent.targetPosition, 0.1f);

        if (agent.transform.position == agent.targetPosition) {
            Debug.Log("Exiting WalkToPosition");
            result = Result.SUCCESS;
        }

        return result;
    }
}
